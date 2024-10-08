using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    
      public  class TimeSlot : BaseEntity
    {
       
        public TimeOnly AppointmentTime { get; set; }
        public Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }
        public bool IsActive { get; set; }
    }
}
