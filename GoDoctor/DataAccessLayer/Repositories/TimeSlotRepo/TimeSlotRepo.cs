using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.TimeSlotRepo
{
    public class TimeSlotRepo : GenericRepo<TimeSlot>, ITimeSlotRepo
    {
        public TimeSlotRepo(GoDoctorContext context) : base(context)
        {
        }
        public async Task<IEnumerable<TimeSlot>> GetTimeSlotByAppointment(int appointmentId)
        {
            var currentTime = TimeOnly.FromDateTime(DateTime.Now);
            return await context.TimeSlots
                .Where(t => t.AppointmentId == appointmentId)
               // .Where(t => t.AppointmentTime >= currentTime)
                .ToListAsync();
        }

    }
}
