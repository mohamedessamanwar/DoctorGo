using DataAccessLayer.Data.Models;
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
        private readonly IUnitOfWork unitOfWork ;
        public SpecialtyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SelectListItem>> GetSpecialtiesToSelect()
        {
            return (await unitOfWork.SpecialtyRepository.GetSpecialtiesToSelect()).Select(s=> new SelectListItem { Value= s.Id.ToString() , Text=s.Name} ).ToList();
            
        }
    }
}
