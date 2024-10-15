using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.AppointmentRepo
{
    public interface IAppointmentRepo : IGenericRepo<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointments(int DoctorId);
        Task<decimal> GetPrice(int appId);
    }
}
