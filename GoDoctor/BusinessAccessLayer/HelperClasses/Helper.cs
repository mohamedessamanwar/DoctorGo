using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.HelperClasses
{
    public static class Helper
    {
        public const string ImagesDoctorPath = "C:\\Users\\DELL\\OneDrive\\Desktop\\doctorGO\\GoDoctor\\GoDoctor\\wwwroot\\Img\\Doctors";
        public static string AllowedExtensions = ".jpg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
        public static string URLDoctor = "https://localhost:44326/Images/Doctor";

        public static async Task<string> SaveImages(IFormFile file, string ImagePath, string Url)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var path = Path.Combine(ImagePath, coverName);
            using var stream = File.Create(path);
            await file.CopyToAsync(stream);
            coverName = $"{Url}/{coverName}";
            return coverName;
        }
    }
}