using BusinessAccessLayer.DataViews.Appointment;
using BusinessAccessLayer.DataViews.DoctorView;
using DataAccessLayer.Data.Models;
using DataAccessLayer.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<CreateResult> Create(AddAppointment addAppointment)
        {
            var Doc = await unitOfWork.doctorRepository.GetDocterByUserId(addAppointment.UserId);
            Appointment appointment = new Appointment()
            {
                AppointmentDay = addAppointment.AppointmentDay,
                CreatedDate = DateTime.Now,
                DoctorId = Doc.Id,
                IsDeleted = false,
                TimeSlots = addAppointment.AppointmentTime.Select(e => new TimeSlot()
                {
                    IsActive = true,
                    AppointmentTime = e

                }).ToList(),
            };
            await unitOfWork.AppointmentRepo.AddAsync(appointment);
            var result = await unitOfWork.CompleteAsync();
            if (result == 0)
            {
                return new CreateResult()
                {
                    IsAdded = false,
                    Errors = "Some Thing Errors"
                };
            }
            return new CreateResult();
        }

        public async Task<List<AppointmentView>> GetAllAppointment(int DoctorId)
        {
            var result = await unitOfWork.AppointmentRepo.GetAppointments(DoctorId);
            if (result == null)
            {
                return new List<AppointmentView>();

            }
            return result.Select(appointment => new AppointmentView() {
                AppointmentDay = appointment.AppointmentDay,
                Id = appointment.Id,
            }
            ).ToList();

        }
    }
}