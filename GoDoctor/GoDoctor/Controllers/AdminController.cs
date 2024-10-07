using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoDoctor.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(policy:"Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
