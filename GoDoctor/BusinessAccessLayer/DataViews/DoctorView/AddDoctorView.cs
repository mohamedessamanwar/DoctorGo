using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace BusinessAccessLayer.DataViews.DoctorView
{
    public class AddDoctorView
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

        [MaxLength(50)]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Max length is 100")]
        public string City { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Password { get; set; }

        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public int SpecialtyId { get; set; }
        public IEnumerable<SelectListItem> Specialties { get; set; } = new List<SelectListItem>();

        [MaxLength(50)]
        public string ClinicAddress { get; set; }
        [MaxLength(50)]
        public string ClinicCity { get; set; }

        
        public decimal Price { get; set; }


    }
}
