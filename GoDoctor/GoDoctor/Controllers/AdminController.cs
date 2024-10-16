using BusinessAccessLayer.DataViews.AuthView;
using BusinessAccessLayer.Sevices.AuthService;
using BusinessAccessLayer.Sevices.DoctorService;
using BusinessAccessLayer.Sevices.SpecialtyService;
using DataAccessLayer.Data.Models;
using DataAccessLayer.UnitOfWorkRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoDoctor.Controllers
{
    public class AdminController : Controller
    {

        private readonly ISpecialtyService _specialtyService;
        private readonly IDoctorService doctorService;
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;


        public AdminController(UserManager<ApplicationUser> userManager, IDoctorService doctorService, ISpecialtyService specialtyService, IAuthService authService)
        {
            _userManager = userManager;
            this.doctorService = doctorService;
            _specialtyService = specialtyService;
            _authService = authService;


        }

        [Authorize(policy: "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(policy: "Admin")]
        public async Task<IActionResult> DoctorsStatus()
        {
            var doctorsStatus = await doctorService.GetAllDoctorsStatus();
            return View(doctorsStatus);
        }

        [HttpPost]
        [Authorize(policy: "Admin")]

        public async Task<JsonResult> UpdateDoctorStatus(int doctorId, bool isValid)
        {
            bool result = await doctorService.UpdateDoctorStatus(doctorId, isValid);
            return Json(new { success = result });
        }

        [HttpGet]
        [Authorize(policy: "Admin")]

        public async Task<IActionResult> SpecialtyManagement()
        {
            var specialties = await _specialtyService.GetAllSpecialties();
            return View(specialties);
        }


        [HttpPost]
        [Authorize(policy: "Admin")]
        public async Task<IActionResult> AddSpecialty(string name, string description)
        {
            await _specialtyService.AddSpecialty(name, description);
            TempData["SuccessMessage"] = "Specialty added successfully.";
            return RedirectToAction("SpecialtyManagement");
        }

        [HttpPost]
        [Authorize(policy: "Admin")]

        public async Task<IActionResult> DeleteSpecialty(int specialtyId)
        {
            await _specialtyService.DeleteSpecialty(specialtyId);
            return RedirectToAction("SpecialtyManagement");
        }

        // Action to show the form for adding a new admin 
        [HttpGet]
        public IActionResult AddNewAdmin()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddNewAdmin(SignupView signupView)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid form data!";
                return View(signupView);
            }
            var result = await _authService.AddNewAdmin(signupView);

            if (result.IsAuth)
            {
                TempData["SuccessMessage"] = "Admin added successfully!";
                return RedirectToAction("AdminList");
            }
            else
            {
                TempData["ErrorMessage"] = result.Errors;
                return View(signupView);
            }
        }


        [HttpGet]
        public async Task<IActionResult> AdminList()
        {
            var users = await _userManager.Users.ToListAsync();
            var adminUsers = new List<ApplicationUser>();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    adminUsers.Add(user);
                }
            }

            return View("AdminList", adminUsers);
        }

    }
}
