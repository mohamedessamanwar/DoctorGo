﻿using BusinessAccessLayer.DataViews.AuthView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.AuthService
{
    public interface IAuthService
    {
        Task<AuthResult> Regestration(SignupView account);
        Task<AuthResult> LogIn(LoginView account);
        Task<bool> ForgetPassword(ForgetPasswordView forgetPasswordView); 
        Task LogOut();
        Task<string> ResetPassword(ResetPasswordViewModel model);
    }
}
