
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoDoctor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("Home/Errors")]
        public IActionResult Errors()
        {
            return View(); // Returns the Error.cshtml view
        }


    }
}
