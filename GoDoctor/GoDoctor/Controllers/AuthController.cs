using Microsoft.AspNetCore.Mvc;
using BusinessAccessLayer.DataViews.AuthView;
using BusinessAccessLayer.Sevices.AuthService;
using Microsoft.AspNetCore.Identity;
using Stripe;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            var LoginView = new ForgetPasswordView();
            return View(LoginView);
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordView forgetPasswordView)
        {
            if (!ModelState.IsValid)
            {
                return View(forgetPasswordView);

            }
            bool Result = await _authService.ForgetPassword(forgetPasswordView);
            if (!Result)
            {
                ModelState.AddModelError("Email", "Email Is Invalid");
                return View(forgetPasswordView);

            }
            return View("ConfirmationSendEmail");
        }
        [HttpGet]
        public IActionResult ResetPassword(string token)
        {
            var LoginView = new ResetPasswordViewModel() { Token = token };
            return View(LoginView);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordViewModel);
            }
            var Result = await _authService.ResetPassword(resetPasswordViewModel);
            if (!Result.IsNullOrEmpty())
            {
                ModelState.AddModelError("", Result);
                return View(resetPasswordViewModel);

            }
            return RedirectToAction("Login", "Auth");

        }

        [HttpGet]
        [Authorize]
        public IActionResult ResetPasswordView()
        {
            var view = new ResetPasswordView();
            return View(view);
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> ResetPasswordView(ResetPasswordView resetPasswordView)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordView);
            }

            // Get the user ID from claims
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
            if (UserId == null)
            {
                return RedirectToAction("Login", "Auth");  // Added 'return' to stop execution if user is not logged in
            }

            // Call the reset password service
            var result = await _authService.ResetPassword(resetPasswordView, UserId);

            if (!string.IsNullOrEmpty(result))
            {
                ModelState.AddModelError("", result);  // Add a generic error to ModelState
                return View(resetPasswordView);  // Re-render view with the error
            }
            return RedirectToAction("Login", "Auth");
        }

    }
}