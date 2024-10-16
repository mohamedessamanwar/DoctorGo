using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SpecialtyRepo
{
    public interface ISpecialtyRepository: IGenericRepo<Specialty>
    {
        Task<IEnumerable<Specialty>> GetSpecialtiesToSelect();
        Task AddAsync(Specialty specialty);
        Task<bool> DeleteAsync(int specialtyId);
        Task<IEnumerable<Specialty>> GetAllAsync();
    }
}
