using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.AppointmentRepo
{
    public class AppointmentRepo : GenericRepo<Appointment>, IAppointmentRepo
    {
        public AppointmentRepo(GoDoctorContext context) : base(context)
        {
        }
    }
}
