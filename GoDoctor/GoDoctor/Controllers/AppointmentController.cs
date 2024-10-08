using BusinessAccessLayer.DataViews.Appointment;
using BusinessAccessLayer.Sevices.AppointmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoDoctor.Controllers
{
    [Authorize(Policy ="Doctor")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public IActionResult Create()
        {
            AddAppointment addAppointment = new AddAppointment();
            return View(addAppointment);
        }
        [HttpPost]
        public async Task <IActionResult> Create(AddAppointment addAppointment)
        {
            if (!ModelState.IsValid)
            {
                return View(addAppointment);
            }
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "uid").Value;
            if (UserId == null)
            {
                RedirectToAction("Login", "Auth");
            }
            addAppointment.UserId = UserId;
            // go to service  . 
            var result = await appointmentService.Create(addAppointment);
            if (result.IsAdded == false) { 
               ModelState.AddModelError("",result.Errors);
               return View(addAppointment);
            }
            return RedirectToAction("DoctorDashboard", "Doctor"); 
        }
                
                
    }

}
