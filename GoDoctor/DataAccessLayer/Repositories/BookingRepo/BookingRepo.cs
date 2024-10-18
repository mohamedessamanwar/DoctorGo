using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.BookingRepo
{
    public class BookingRepo : GenericRepo<Booking>, IBookingRepo
    {
        public BookingRepo(GoDoctorContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Booking>> GetDoctorBooking(string userId)
        {
            return await context.Bookings.AsNoTracking().Include(b => b.User).Include(b => b.TimeSlot).
               ThenInclude(t => t.Appointment).ThenInclude(a => a.Doctor).Where(b => b.TimeSlot.Appointment.Doctor.ApplicationUserId == userId).Where(b=>b.TimeSlot.Appointment.AppointmentDay==DateOnly.FromDateTime(DateTime.Now))
               .Where(a=>a.PaymentStatus== "Complete")
               .ToListAsync();             
        }
        public async Task<Booking> GetDoctorBook(int bookId)
        {
            return await context.Bookings.AsNoTracking().Include(b => b.User).Include(b => b.TimeSlot).
               ThenInclude(t => t.Appointment).ThenInclude(a => a.Doctor).ThenInclude(d=>d.ApplicationUser).FirstOrDefaultAsync(b => b.Id == bookId);
        }
    }
}
