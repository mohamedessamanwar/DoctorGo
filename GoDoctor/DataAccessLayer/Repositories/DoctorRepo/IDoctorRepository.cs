using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.DoctorRepo
{
    public interface IDoctorRepository : IGenericRepo<Docktor>
    {
        Task<int> GetDocktorsCount(int specialty, string governorate, string doctor, int page);
        Task<IEnumerable<Docktor>> GetDocktors(int specialty, string governorate, string doctor, int page);
        Task<Docktor?> GetDocterByUserId(string userId);
        Task<IEnumerable<Docktor>> GetAllDoctors();
        Task<Docktor?> GetDocterById(int DocId);
    }
}
