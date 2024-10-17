using BusinessAccessLayer.DataViews.CommentView;
using BusinessAccessLayer.DataViews.DoctorView;
using BusinessAccessLayer.Sevices.DoctorService;
using BusinessAccessLayer.Sevices.SpecialtyService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoDoctor.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ISpecialtyService specialtyService;
        private readonly IDoctorService doctorService;

        public DoctorController(ISpecialtyService specialtyService, IDoctorService doctorService = null)
        {
            this.specialtyService = specialtyService;
            this.doctorService = doctorService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GoAsDoctor()
        {
            AddDoctorView addDoctorView = new AddDoctorView()
            {
                Specialties = await specialtyService.GetSpecialtiesToSelect()
            }; 
            return View(addDoctorView);
        }
        [HttpPost]
        public async Task<IActionResult> GoAsDoctor(AddDoctorView addDoctorView)
        {
            // Ensure the model is valid (check data annotations, etc.)
            if (!ModelState.IsValid)
            {
                // If model validation fails, reload specialties and return to the view
                addDoctorView.Specialties = await specialtyService.GetSpecialtiesToSelect();
                return View(addDoctorView);
            }

            try
            {
                // Call the method to add the doctor (as seen in the previous implementation)
                var result = await doctorService.AddDoctor(addDoctorView);

                if (result.IsAdded)
                {
                    // Success: Redirect to a success page or show success message
                    return View("DoctorSuccess"); // Create a success action or page
                }
                else
                {
                    // Failure: Show errors returned by AddDoctor
                    ModelState.AddModelError("", result.Errors);
                }
            }
            catch (Exception ex)
            {
                // Log the exception, and add an error to ModelState to inform the user
                ModelState.AddModelError("", $"An unexpected error occurred: {ex.Message}");
            }

            // Reload the specialties if something goes wrong and return to the view
            addDoctorView.Specialties = await specialtyService.GetSpecialtiesToSelect();
            return View(addDoctorView);
        }


        [HttpGet]
        public async Task<IActionResult> ViewDoctors()
        {
         //   throw new NotImplementedException();
            ViewBag.Specialties = await specialtyService.GetSpecialtiesToSelect();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ViewDoctors1(int specialty, string governorate, string doctor, int page)
        {
            var result = await doctorService.DoctorSearch(specialty, governorate, doctor, page);
            if (result.Count() == 0) {
                return NotFound( new {massage = "No Doctor Match Search" });
            }
            return Ok ( new { data = result });
        }


        [HttpGet]
        [Authorize(policy:"Doctor")]
        public IActionResult DoctorDashboard()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var doctor = await doctorService.GetDocterById(id);
            return View(doctor);
        }
    }
}
