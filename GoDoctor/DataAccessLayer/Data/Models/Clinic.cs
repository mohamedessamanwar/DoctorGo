using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    public class Clinic:BaseEntity
    {
        [MaxLength(50)]
        public string ClinicAddress { get; set; }
        [MaxLength(50)]
        public string ClinicCity { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public int DocktorId { get; set; }
        public Docktor Docktor { get; set; }

    }
}
