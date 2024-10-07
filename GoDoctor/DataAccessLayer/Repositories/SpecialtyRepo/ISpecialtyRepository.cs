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
    }
}
