using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.DoctorView
{
    public class DoctorSearchViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string image { get; set; }
        public string specialtyName { get; set; }
        public string specialtyDescription { get; set;}
    }
}
