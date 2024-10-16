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
            return await context.Specialty.AsNoTracking().Select(s => new Specialty { Id = s.Id, Name = s.Name }).ToListAsync();
        }
        public async Task AddAsync(Specialty specialty)
        {
            await context.Specialty.AddAsync(specialty);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int specialtyId)
        {
            var specialty = await context.Specialty.FindAsync(specialtyId);
            if (specialty == null) return false;

            specialty.IsDeleted = true; // Soft delete
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Specialty>> GetAllAsync()
        {
            return await context.Specialty.Where(s => (bool)!s.IsDeleted).ToListAsync();
        }
    }

}

