
using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.DoctorRepo
{
    public class DoctorRepository : GenericRepo<Docktor> , IDoctorRepository
    {
        public DoctorRepository(GoDoctorContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Docktor>> GetDocktors(int specialty, string governorate, string doctor, int page)
        {
            var quary = context.Docktor.AsNoTracking().Include(d => d.Clinic).Include(d => d.Specialty).Include(d => d.ApplicationUser).AsQueryable();
            if (specialty !=0 ){
                quary = quary.Where(d => d.SpecialtyId == specialty);           
            
            }
            if (!governorate.IsNullOrEmpty())
            {
                quary = quary.Where(d => d.ApplicationUser.City==governorate);
            }
            if (!doctor.IsNullOrEmpty())
            {
                quary = quary.Where(d => string.Concat(d.ApplicationUser.FirstName, d.ApplicationUser.LastName) == doctor);
            } 
            return quary.Skip((page - 1) * 10).Take(10).ToList();
        }
        public async Task<int> GetDocktorsCount(int specialty, string governorate, string doctor, int page)
        {
            var quary = context.Docktor.AsNoTracking().Include(d => d.Clinic).Include(d => d.Specialty).Include(d => d.ApplicationUser).AsQueryable();
            if (specialty != 0)
            {
                quary = quary.Where(d => d.SpecialtyId == specialty);

            }
            if (!governorate.IsNullOrEmpty())
            {
                quary = quary.Where(d => d.ApplicationUser.City == governorate);
            }
            if (!doctor.IsNullOrEmpty())
            {
                quary = quary.Where(d => string.Concat(d.ApplicationUser.FirstName, d.ApplicationUser.LastName) == doctor);
            }
            return await quary.CountAsync();
        }
        public async Task<Docktor?> GetDocterByUserId(string userId) {
           return await context.Docktor.AsNoTracking().FirstOrDefaultAsync(d=> d.ApplicationUserId==userId);
           
         
        }

        public async Task<Docktor?> GetDocterById(int DocId)
        {
            return await context.Docktor.AsNoTracking()
                .Include(d => d.Clinic).Include(d => d.Specialty).Include(d => d.ApplicationUser).Include(d => d.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(d => d.Id == DocId);
        }
        public async Task<IEnumerable<Docktor>> GetAllDoctors()
        {
            return await context.Docktor
                .Include(d => d.ApplicationUser) // Include related user info
                .ToListAsync();
        }
    }
}
