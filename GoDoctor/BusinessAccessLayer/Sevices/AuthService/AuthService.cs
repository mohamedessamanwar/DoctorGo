﻿using BusinessAccessLayer.DataViews.AuthView;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessAccessLayer.Sevices.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            await _userManager.AddToRoleAsync(user, "Patient");
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
            await _signInManager.SignInAsync(user, false);
            return new AuthResult();

        }

        private async Task<string> AddClaimsAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

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
                   Errors = "Email Or Passward Is Not Correct" 
               };
               
            }
            if (user is null || !await _userManager.CheckPasswordAsync(user, account.Password))
            {
                return new AuthResult()
                {
                    Errors = "Email Or Passward Is Not Correct"
                };
            }
            // Sign in the user
            var signInResult = await _signInManager.PasswordSignInAsync(user, account.Password, isPersistent: false, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                return new AuthResult()
                {
                    Errors = "Failed to sign in"
                };
            }

            // Return success result
            return new AuthResult()
            {
                IsAuth = true
            };

        }
        public async Task LogOut()
        {

            await _signInManager.SignOutAsync();
        }

    }
}
