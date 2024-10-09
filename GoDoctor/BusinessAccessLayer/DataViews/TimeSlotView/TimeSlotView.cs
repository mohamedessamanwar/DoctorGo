using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.TimeSlotView
{
    public class TimeSlotView
    {
        public TimeOnly AppointmentTime { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
