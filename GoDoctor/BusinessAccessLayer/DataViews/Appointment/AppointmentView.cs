using DataAccessLayer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.Appointment
{
    public class AppointmentView
    {
        public int Id { get; set; }
   
        public DateOnly AppointmentDay { get; set; }
      
    }
}
