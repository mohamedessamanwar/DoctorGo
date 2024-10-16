using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.SpecialtyRepo;
using DataAccessLayer.UnitOfWorkRepo;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.SpecialtyService
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISpecialtyRepository _specialtyRepository;

        public SpecialtyService(IUnitOfWork unitOfWork, ISpecialtyRepository specialtyRepository)
        {
            this.unitOfWork = unitOfWork;
            _specialtyRepository = specialtyRepository;

        }

        public async Task<IEnumerable<SelectListItem>> GetSpecialtiesToSelect()
        {
            return (await unitOfWork.SpecialtyRepository.GetSpecialtiesToSelect()).Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();

        }

        public async Task AddSpecialty(string name, string description)
        {
            var specialty = new Specialty { Name = name, Description = description, IsDeleted = false };
            await _specialtyRepository.AddAsync(specialty);

        }

        public async Task<bool> DeleteSpecialty(int specialtyId)
        {
            return await _specialtyRepository.DeleteAsync(specialtyId);
        }

        public async Task<IEnumerable<Specialty>> GetAllSpecialties()
        {
            return await _specialtyRepository.GetAllAsync();
        }
    }
}
