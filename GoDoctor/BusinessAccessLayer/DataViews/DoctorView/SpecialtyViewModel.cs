using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.DoctorView
{
    internal class SpecialtyViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
