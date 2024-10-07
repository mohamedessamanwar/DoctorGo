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
    }
}
