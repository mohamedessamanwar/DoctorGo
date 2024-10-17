using BusinessAccessLayer.DataViews.Appointment;
using BusinessAccessLayer.Sevices.BookingService;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoDoctor.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        [HttpGet]
        [Authorize("Patient")]
        public async Task<IActionResult> Book(int TimeSlotId)
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            if (UserId == null)
            {
                RedirectToAction("Login", "Auth");
            }
            var result = await bookingService.BookAppointment(TimeSlotId,UserId);
            if (!result.IsBook) { 
               return RedirectToAction("Home", "Index");
            }
            Response.Headers.Add("Location",result.SessionId);
            return new StatusCodeResult(303);
        }

        public async Task<IActionResult> BookingConfirmation(int bookId)
        {
            var result = await bookingService.Confirmation(bookId);
            ViewBag.isBookingSuccessful = result.IsBook;
            return View();

        }
        [HttpGet]
        [Authorize("Doctor")]
        public async Task<IActionResult> DoctorBooking()
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            if (UserId == null)
            {
                RedirectToAction("Login", "Auth");
            }
            var result = await bookingService.GetDoctorBooking( UserId);
            return View(result);


        }


    }
}
