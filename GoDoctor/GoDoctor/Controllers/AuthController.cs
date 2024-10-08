using Microsoft.AspNetCore.Mvc;
using BusinessAccessLayer.DataViews.AuthView;
using BusinessAccessLayer.Sevices.AuthService;
using Microsoft.AspNetCore.Identity;
namespace GoDoctor.Controllers
{
    public class AuthController : Controller

    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        [HttpGet]
        public IActionResult Signup()
        {
            var SignupView = new SignupView();
            return View(SignupView);
        }
        [HttpPost]
        public async Task<IActionResult> Signup(SignupView signupView)
        {
            if (!ModelState.IsValid)
            {
                return View(signupView);
            }
            var result = await _authService.Regestration(signupView);
            if (result.IsAuth == false)
            {
                ModelState.AddModelError("", result.Errors);
                return View(signupView);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult Login()
        {
            var LoginView = new LoginView();
            return View(LoginView);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginView model)
        {
            if (!ModelState.IsValid)
            {
                // If the model is not valid, return the view with the current model
                return View(model);
            }

            // Call the login service
            var result = await _authService.LogIn(model);

            if (!result.IsAuth)
            {

                // If login fails, add error to the model and return to the view
                ModelState.AddModelError("", result.Errors);
                return View(model);
            }
            if (result.Role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            if (result.Role == "Doctor")
            {
                return RedirectToAction("DoctorDashboard", "Doctor");
            }
            return RedirectToAction("Index", "Home");

        }

       // [HttpPost]
      //  [ValidateAntiForgeryToken] // Protects against CSRF attacks
        public async Task<IActionResult> Logout()
        {
            // Sign the user out
            await _authService.LogOut();
            // Redirect to the homepage or login page after logging out
            return RedirectToAction("Index", "Home");
        }
    }
}