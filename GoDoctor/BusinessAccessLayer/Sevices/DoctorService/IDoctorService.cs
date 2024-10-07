using BusinessAccessLayer.DataViews.DoctorView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.DoctorService
{
    public interface IDoctorService
    {
        Task<CreateResult> AddDoctor(AddDoctorView addDoctorView);
        Task<IEnumerable<DoctorSearchViewModel>> DoctorSearch(int specialty, string governorate, string doctor, int page);
    }
}
