using BusinessAccessLayer.Services.PaymentService;
using DataAccessLayer.Data.Models;
using DataAccessLayer.UnitOfWorkRepo;
using Stripe.Climate;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.HelperClasses;
using BusinessAccessLayer.DataViews.BookingView;
using BusinessAccessLayer.Services.Email;

namespace BusinessAccessLayer.Sevices.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPayment payment;
        private readonly IMailingService mailingService;
        public BookingService(IUnitOfWork unitOfWork, IPayment payment, IMailingService mailingService)
        {
            this.unitOfWork = unitOfWork;
            this.payment = payment;
            this.mailingService = mailingService;
        }


        public async Task<BookingResult> BookAppointment(int TimeSlotId, string UserId)
        {
            using (var t = await unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.Serializable))
            {
                try
                {
                    var TimeSlot = await unitOfWork.timeSlotRepo.GetByIdAsync(TimeSlotId);//1
                    if (TimeSlot == null || TimeSlot.IsActive == false)
                    {
                        return new BookingResult()
                        {
                            Errors = "Time Is Not Active",
                            IsBook = false,
                        };
                    }
                    TimeSlot.IsActive = false;
                    unitOfWork.timeSlotRepo.Update(TimeSlot, nameof(TimeSlot.IsActive)); //2
                    var Booking = new Booking()
                    {
                        TimeSlotId = TimeSlotId,
                        UserId = UserId,
                        BookingState = "Proccessing",
                        PaymentStatus = "Proccessing",
                        FinalPrice = await unitOfWork.AppointmentRepo.GetPrice(TimeSlot.AppointmentId),
                        CreatedDate = DateTime.Now,
                        IsDeleted = false,
                        PaymentType = "online"
                    };
                    await unitOfWork.BookingRepo.AddAsync(Booking);//2
                    await unitOfWork.CompleteAsync(); //ex
                    var payment = await this.payment.Payment(Booking);
                    if (payment.status == false)
                    {
                        unitOfWork.Rollback();
                        return new BookingResult()
                        {
                            Errors = "Wrong IN Payment",
                            IsBook = false,
                        };
                    }
                    await UpdateStripePaymentId(Booking, payment.session.Id, payment.session.PaymentIntentId); //2
                    await unitOfWork.CompleteAsync();
                    unitOfWork.Commit();
                    return new BookingResult()
                    {
                        Errors = "",
                        IsBook = true,
                        SessionId = payment.session.Url,
                    };

                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    return new BookingResult()
                    {
                        Errors = "Wrong IN Payment",
                        IsBook = false,
                    };

                }
            }
        }

        public async Task<BookingResult> Confirmation(int bookId)
        {
            var booking = await unitOfWork.BookingRepo.GetDoctorBook(bookId); //1  include slote with tracking 
            var paymentStatus = payment.PaymentStatus(booking.SessionId);
            var session = payment.PaymentSession(booking.SessionId);
            // path if user InComplete payment .
            if (session.PaymentIntentId == null)
            {
                await UpdateOrderStatus(booking, "InComplete");
                // update slot .
                var TimeSlot = await unitOfWork.timeSlotRepo.GetByIdAsync(booking.TimeSlotId);
                TimeSlot.IsActive=true;
                unitOfWork.timeSlotRepo.Update(TimeSlot , nameof(TimeSlot.IsActive));
                // update booksatus .
                await unitOfWork.CompleteAsync();
                return new BookingResult()
                {
                    IsBook = false,
                };
            }
            await UpdateStripePaymentId(booking, session.Id, session.PaymentIntentId);
            // path if user Complete payment .
            if (paymentStatus == "paid")
            {
                await UpdateOrderStatus(booking, "Complete"); 
                await unitOfWork.CompleteAsync();
                // Email to the User (Appointment Confirmation)
                string userEmailSubject = "Appointment Confirmation with Dr. " + booking.TimeSlot.Appointment.Doctor.ApplicationUser.FirstName;
                string userEmailBody = $@"
                 Dear {booking.User.FirstName},
 
                 Your appointment with Dr. {booking.TimeSlot.Appointment.Doctor.ApplicationUser.FirstName} on {booking.TimeSlot.Appointment.AppointmentDay:MMMM dd, yyyy} at {booking.TimeSlot.AppointmentTime} has been confirmed.
                 Best regards,
                 [GoDoctor]";

                await mailingService.SendEmailAsync(booking.User.Email, userEmailSubject, userEmailBody);

                // Email to the Doctor (New Appointment Notification)
                string doctorEmailSubject = "New Appointment with " + booking.User.FirstName;
                string doctorEmailBody = $@"
                Dear Dr. {booking.TimeSlot.Appointment.Doctor.ApplicationUser.FirstName},

                You have a new appointment with {booking.User.FirstName} on {booking.TimeSlot.Appointment.AppointmentDay:MMMM dd, yyyy} at {booking.TimeSlot.AppointmentTime}.

                Best regards,
                [GoDoctor]";

                await mailingService.SendEmailAsync(booking.TimeSlot.Appointment.Doctor.ApplicationUser.Email, doctorEmailSubject, doctorEmailBody);

                return new BookingResult()
                {
                    IsBook = true,
                };
            }
            var rp = await payment.CancelPayment(booking.PaymentIntentId);
            if (!rp.status)
            {
                await UpdateOrderStatus(booking, "Canceled Failed");
                var TimeSlot1 = await unitOfWork.timeSlotRepo.GetByIdAsync(booking.TimeSlotId);
                TimeSlot1.IsActive = true;
                unitOfWork.timeSlotRepo.Update(TimeSlot1, nameof(TimeSlot1.IsActive));
                await unitOfWork.CompleteAsync();
                return new BookingResult()
                {
                    IsBook = false,
                };
            }
            await UpdateOrderStatus(booking, "Canceled");
            var TimeSlot2 = await unitOfWork.timeSlotRepo.GetByIdAsync(booking.TimeSlotId);
            TimeSlot2.IsActive = true;
            unitOfWork.timeSlotRepo.Update(TimeSlot2, nameof(TimeSlot2.IsActive));
            await unitOfWork.CompleteAsync();
            return new BookingResult()
            {
                IsBook = false,
            };
        }
        private async Task UpdateOrderStatus(Booking booking, string paymentPaid)
        {
            booking.PaymentStatus = paymentPaid;
            booking.UpdatedDate = DateTime.UtcNow;
            unitOfWork.BookingRepo.Update(booking, nameof(booking.PaymentStatus), nameof(booking.UpdatedDate));
            return;
        }
        private async Task UpdateStripePaymentId(Booking book, string id, string paymentIntentId)
        {
            book.PaymentIntentId = paymentIntentId;
            book.SessionId = id;
            book.UpdatedDate = DateTime.UtcNow;
            unitOfWork.BookingRepo.Update(book, nameof(book.SessionId), nameof(book.UpdatedDate), nameof(book.PaymentIntentId));
            return;
        }
        public async Task<IEnumerable<DoctorBookingView>> GetDoctorBooking(string userId)
        {
            var result = await unitOfWork.BookingRepo.GetDoctorBooking(userId);
            if (result == null)
            {
                return (IEnumerable<DoctorBookingView>)Enumerable.Empty<Booking>();
            }
            return result.Select(b => new DoctorBookingView()
            {
                AppointmentDay = b.TimeSlot.Appointment.AppointmentDay,
                AppointmentTime = b.TimeSlot.AppointmentTime,
                BookingState = b.BookingState,
                PaymentStatus = b.PaymentStatus,
                Name = b.User.FirstName + " " + b.User.LastName,
                Email = b.User.Email,
                City = b.User.City,
            }).ToList();
        }
    }
    }

    
