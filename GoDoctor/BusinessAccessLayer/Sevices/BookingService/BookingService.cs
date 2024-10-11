﻿using BusinessAccessLayer.Services.PaymentService;
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

namespace BusinessAccessLayer.Sevices.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPayment payment;

        public BookingService(IUnitOfWork unitOfWork, IPayment payment)
        {
            this.unitOfWork = unitOfWork;
            this.payment = payment;
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
                        FinalPrice = 100,
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
                catch (Exception ex) {
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
            var booking = await unitOfWork.BookingRepo.GetByIdAsync(bookId); //1
            var paymentStatus = payment.PaymentStatus(booking.SessionId);
            var session = payment.PaymentSession(booking.SessionId);
            await UpdateStripePaymentId(booking, session.Id, session.PaymentIntentId); //2
            if (paymentStatus == "paid")
            {
                await UpdateOrderStatus(booking, "Complete"); // 2
                await unitOfWork.CompleteAsync();
                return new BookingResult()
                {
                    IsBook = true,
                };
            }
            var rp = await payment.CancelPayment(booking.PaymentIntentId);
            if (!rp.status)
            {
                await UpdateOrderStatus(booking, "Canceled Failed");
                unitOfWork.BookingRepo.Delete(booking);
                await unitOfWork.CompleteAsync();
                return new BookingResult()
                {
                    IsBook = false,
                };
            }
            await UpdateOrderStatus(booking, "Canceled");
            unitOfWork.BookingRepo.Delete(booking);
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

    }
    }

    
