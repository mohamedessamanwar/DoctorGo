using Microsoft.AspNetCore.Mvc;

namespace GoDoctor.Controllers
{
    public class DoctorDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
