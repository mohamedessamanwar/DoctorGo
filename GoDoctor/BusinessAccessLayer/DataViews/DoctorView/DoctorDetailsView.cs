using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.DataViews.CommentView;

namespace BusinessAccessLayer.DataViews.DoctorView
{
    public class DoctorDetailsView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string image { get; set; }
        public string specialtyName { get; set; }
        public string specialtyDescription { get; set; }
        public string ClinicAddress { get; set; }
        public string ClinicCity { get; set; }
        public IEnumerable<DoctorCommentsView> commentViews { get; set; }
    }
}
