using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    [Table(name: "Doctors")]
    public class Docktor : BaseEntity
    {
        public bool IsValid { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public Clinic Clinic { get; set; } 
        [MaxLength(100)]
        public string ImgeUrl {  get; set; } 
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
        public decimal Price { get; set; }
        public  ICollection<Appointment> Appointments { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
