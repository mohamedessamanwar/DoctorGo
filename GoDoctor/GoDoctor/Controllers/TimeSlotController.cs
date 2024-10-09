using BusinessAccessLayer.Sevices.TimeSlotService;
using Microsoft.AspNetCore.Mvc;

namespace GoDoctor.Controllers
{
    public class TimeSlotController : Controller
    {
        private readonly ITimeSlotService timeSlotService;
        public TimeSlotController(ITimeSlotService timeSlotService = null)
        {
            this.timeSlotService = timeSlotService;
        }

        public async Task<IActionResult> ViewTimeSlot(int appointmentId)
        {
           var result = await timeSlotService.GetTimeSlotByAppointment(appointmentId);
            return View(result);
        }
    }
}
