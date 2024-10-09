using BusinessAccessLayer.DataViews.Appointment;
using BusinessAccessLayer.DataViews.DoctorView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.AppointmentService
{
    public interface IAppointmentService
    {
        Task<CreateResult> Create(AddAppointment addAppointment);
        Task<List<AppointmentView>> GetAllAppointment(int DoctorId);
    }
}
