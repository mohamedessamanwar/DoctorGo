using BusinessAccessLayer.Sevices.AppointmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.Appointment
{
    public class AddAppointment 
    {
        public DateOnly AppointmentDay { get; set; }
        public IEnumerable<TimeOnly> AppointmentTime { get; set; }
        public string? UserId { get; set; }
    }
}
