using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.DoctorView
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ClinicAddress { get; set; }
        public string ImageUrl { get; set; }
    }

}
