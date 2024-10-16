using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.DoctorView
{
    public class DoctorStatusViewModel
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public bool IsValid { get; set; }
    }
}
