using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.BookingRepo
{
    public interface IBookingRepo:IGenericRepo<Booking>
    {
         Task<IEnumerable<Booking>> GetDoctorBooking(string userId);
         Task<Booking> GetDoctorBook(int bookId);
    }
}
