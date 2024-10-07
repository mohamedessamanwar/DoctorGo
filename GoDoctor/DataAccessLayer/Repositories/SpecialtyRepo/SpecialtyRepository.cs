using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SpecialtyRepo
{
    public class SpecialtyRepository : GenericRepo<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(GoDoctorContext context) : base(context)
        {

            
        }
        public async Task<IEnumerable<Specialty>> GetSpecialtiesToSelect()
        {
            return await context.Specialty.AsNoTracking().Select(s=> new Specialty { Id= s.Id, Name= s.Name}).ToListAsync();
        }
    }
}
