using BusinessAccessLayer.DataViews.TimeSlotView;
using DataAccessLayer.Data.Models;
using DataAccessLayer.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.TimeSlotService
{
    public class TimeSlotService  : ITimeSlotService
    {
        private readonly IUnitOfWork unitOfWork ;

        public TimeSlotService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TimeSlotView>> GetTimeSlotByAppointment(int appointmentId)
        {
           var result = await this.unitOfWork.timeSlotRepo.GetTimeSlotByAppointment(appointmentId);
            return result.Select(x => new TimeSlotView { 
                Id = x.Id,
                AppointmentTime = x.AppointmentTime,
                IsActive = x.IsActive,
                 
            }).ToList();
        }
    }
}
