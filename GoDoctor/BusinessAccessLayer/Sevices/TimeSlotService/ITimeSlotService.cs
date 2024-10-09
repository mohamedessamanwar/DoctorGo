using BusinessAccessLayer.DataViews.TimeSlotView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.TimeSlotService
{
    public interface ITimeSlotService
    {
        Task<IEnumerable<TimeSlotView>> GetTimeSlotByAppointment(int appointmentId);
    }
}
