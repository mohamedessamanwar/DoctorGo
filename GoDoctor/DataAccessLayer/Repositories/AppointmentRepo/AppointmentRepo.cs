using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.AppointmentRepo
{
    public class AppointmentRepo : GenericRepo<Appointment>, IAppointmentRepo
    {
        public AppointmentRepo(GoDoctorContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Appointment>> GetAppointments(int DoctorId){
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            return await context.Appointments.AsNoTracking()
                .Where(a => a.DoctorId == DoctorId)
                .Where(a => a.AppointmentDay >= today)
                .ToListAsync();
        }
        public async Task<decimal> GetPrice(int appId)
        {
            return await context.Appointments.AsNoTracking().Include(a => a.Doctor)
                .Where(a => a.Id == appId).Select(a => a.Doctor.Price).FirstOrDefaultAsync();          
        }
    }
}
