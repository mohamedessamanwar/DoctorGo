using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.BookingView
{
    public class DoctorBookingView
    {
        public string BookingState { get; set; }
        public string PaymentStatus { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public DateOnly AppointmentDay { get; set; }
        public  string Email { get; set; }
        public string   Name { get; set; }  
        public string City { get; set; }

    }
}
