using BusinessAccessLayer.DataViews.BookingView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.BookingService
{
    public interface IBookingService
    {
        Task<BookingResult> BookAppointment(int TimeSlotId, string UserId);
        Task<BookingResult> Confirmation(int bookId);
        Task<IEnumerable<DoctorBookingView>> GetDoctorBooking(string userId);
    }
}
