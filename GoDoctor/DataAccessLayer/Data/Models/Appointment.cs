using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    public class Appointment : BaseEntity
    {
  
        public int DoctorId { get; set; }
        public Docktor Doctor { get; set; } 
        public DateOnly AppointmentDay { get; set; }
       public  ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
    }
    }
