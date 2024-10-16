using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.SpecialtyService
{
    public interface ISpecialtyService
    {
        Task<IEnumerable<SelectListItem>> GetSpecialtiesToSelect();
        Task AddSpecialty(string name, string description);
        Task<bool> DeleteSpecialty(int specialtyId);
        Task<IEnumerable<Specialty>> GetAllSpecialties();
    }
}
