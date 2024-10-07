using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.AuthView
{
    public class SignupView
    {
        [Required]
        [EmailAddress(ErrorMessage = "enter valid email ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "firstname is required")]
        [MaxLength(50)]
        public string Firstname { get; set; }


        [Required(ErrorMessage = "firstname is required")]
        [MaxLength(50)]
        public string Lastname { get; set; }

        

        [Required]
        [MaxLength(100 , ErrorMessage = "Max length is 100")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public string? Role { get; set; }

    }
}
