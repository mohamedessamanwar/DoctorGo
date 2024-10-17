using BusinessAccessLayer.DataViews.AuthView;
using BusinessAccessLayer.Services.Email;
using DataAccessLayer.Data.Models;
using DataAccessLayer.UnitOfWorkRepo;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace BusinessAccessLayer.Sevices.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork unitOfWork ;
        private readonly IMailingService mailingService;

        public AuthService(UserManager<ApplicationUser> userManager, IMailingService mailingService, IUnitOfWork unitOfWork,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.unitOfWork = unitOfWork;
            this.mailingService = mailingService;
        }

        public async Task<AuthResult> Regestration(SignupView account)
        {

            ApplicationUser user = new ApplicationUser();
            user.UserName = account.Email.Split("@")[0];
            user.Email = account.Email;
            user.FirstName = account.Firstname;
            user.LastName = account.Lastname;
            user.City = account.City;
            user.CreatedDate= DateTime.Now;
            user.UpdatedDate= DateTime.Now;
            var result = await _userManager.CreateAsync(user, account.Password);
            if (!result.Succeeded)
            {
                StringBuilder Errors = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    Errors.Append(error.Description);
                }
                return new AuthResult
                {
                    Errors = Errors.ToString() , 
                    IsAuth = false
                }; 
            }
            // Add to role 
           if (account.Role != null) {
                await _userManager.AddToRoleAsync(user, "Doctor");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Patient");
            }
           
            var role = await AddClaimsAsync(user);
            if (role is not null)
            {
                return new AuthResult
                {
                    Errors = role,
                    IsAuth = false
                };

            }
            if (account.Role == null)
            {
                await _signInManager.SignInAsync(user, false);

            }
            // Create cookie and sign in user
          
            return new AuthResult()
            {
                UserId = user.Id
            };

        }


        private async Task<string> AddClaimsAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim(ClaimTypes.Role, role));

            var claims = new[]
            {
                new Claim("UserName", user.UserName),
                new Claim("Id",user.Id) , 
                new Claim("Email", user.Email),
                new Claim("uid", user.Id) ,

            }
            .Union(roleClaims);
            var result = await _userManager.AddClaimsAsync(user, claims);
            string Error = null;
            if (!result.Succeeded)
            {

                foreach (var error in result.Errors)
                {
                    Error += $"{error.Description},";
                }
            }
            return Error;

        }

        public async Task<AuthResult> LogIn(LoginView account)
        {
            var user = await _userManager.FindByEmailAsync(account.Email);
            if (user == null) {
               return new AuthResult()
               {

                   IsAuth = false,
                   Errors = "Email Or Passward Is Not Correct" 
               };
               
            }
            if (user is null || !await _userManager.CheckPasswordAsync(user, account.Password))
            {
                return new AuthResult()
                {

                    IsAuth = false,
                    Errors = "Email Or Passward Is Not Correct"
                };
            }
            // Sign in the user
            var signInResult = await _signInManager.PasswordSignInAsync(user, account.Password, isPersistent: false, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                return new AuthResult()
                {
                    IsAuth = false,
                    Errors = "Failed to sign in"
                };
            }
           
        
        var role = await _userManager.GetRolesAsync(user);


            // Return success result
            return new AuthResult()
            {
                IsAuth = true,
                Role = role.First()
            }; 

        }
        public async Task<AuthResult> AddNewAdmin(SignupView account)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = account.Email.Split("@")[0];
            user.Email = account.Email;
            user.FirstName = account.Firstname;
            user.LastName = account.Lastname;
            user.City = account.City;
            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;
            var result = await _userManager.CreateAsync(user, account.Password);
            if (!result.Succeeded)
            {
                StringBuilder Errors = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    Errors.Append(error.Description);
                }
                return new AuthResult
                {
                    Errors = Errors.ToString(),
                    IsAuth = false
                };
            }
            
            await _userManager.AddToRoleAsync(user, "Admin");   
            var role = await AddClaimsAsync(user);
            if (role is not null)
            {
                return new AuthResult
                {
                    Errors = role,
                    IsAuth = false
                };

            }
            // Create cookie and sign in user
            // await _signInManager.SignInAsync(user, false);
            await mailingService.SendEmailAsync(user.Email, "NewAdmin", $"Your Email is{user.Email} and your password is Mo7amad_2001"); 
            return new AuthResult()
            {
                UserId = user.Id
            };

        }

        public async Task LogOut()
        {

            await _signInManager.SignOutAsync();
        }


        public async Task<bool> ForgetPassword(ForgetPasswordView forgetPasswordView) 
        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(forgetPasswordView.Email);

            // If the user doesn't exist, return false
            if (user == null)
            {
                return false;
            }

            // Generate a password reset token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Create and save the user token
            await unitOfWork.userTokenRepo.AddAsync(new UserToken
            {
                Token = token,
                UserId = user.Id,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
            });
            await unitOfWork.CompleteAsync();
            // Construct the password reset link
            // code value have to be Encoded before sending the call.
            // string codeHtmlVersion = HttpUtility.UrlEncode(token);
            //HttpUtility.UrlEncode converted all plus signs (+) to empty spaces (" ") this is wrong,
            //UrlEncode replaces "+" to
            //"%2b". If you use + with UrlDecode, it will be replaced into whitespace character
              string encodedToken = HttpUtility.UrlEncode(token.Replace("+", "%2b"));
            var Domain = $"https://localhost:44326/Auth/ResetPassword/?token={encodedToken}";
            await mailingService.SendEmailAsync(user.Email, "ResetPassword", Domain);


            // Send the password reset email
         //   var emailSent = await mailingService.SendEmailAsync(user.Email, "Reset Your Password", Domain);

            return true; // Return true if the email was sent successfully
        }
        public async Task<string> ResetPassword(ResetPasswordViewModel model)
        {
            var decodedCode = HttpUtility.UrlDecode(model.Token);
            var Token = await unitOfWork.userTokenRepo.GetUserToken(decodedCode);
            if (Token == null) { return "Inavalid Token"; }
            var user = await _userManager.FindByIdAsync(Token.UserId);
            Token.IsDeleted = true;
            await unitOfWork.CompleteAsync();
            var result = await _userManager.ResetPasswordAsync(user,decodedCode,model.NewPassword);
            if (!result.Succeeded) {
                var errors = new StringBuilder();
                foreach (var error in result.Errors) {
                    errors.Append(error);
                }
                return result.ToString();
            }
            return "";

        }


        public async Task<string> ResetPassword(ResetPasswordView resetPasswordView, string userId)
        {
            // Find the user by their ID
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return "User not found";
            }

            // Attempt to change the password using the old and new password provided
            var result = await _userManager.ChangePasswordAsync(user, resetPasswordView.OldPassword, resetPasswordView.NewPassword);

            // Check if the operation succeeded
            if (result.Succeeded)
            {
                return "";
            }

            // If it failed, return the error messages
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return $"Error changing password: {errors}";
        }

    }
}
