using BusinessAccessLayer.Sevices.AppointmentService;
using BusinessAccessLayer.Sevices.AuthService;
using BusinessAccessLayer.Sevices.DoctorService;
using BusinessAccessLayer.Sevices.SpecialtyService;
using DataAccessLayer.Repositories.SpecialtyRepo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BusinessAccessLayer

{
    public static class BusinessAccessLayerServices
    {
        public static IServiceCollection BusinessAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISpecialtyService, SpecialtyService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            return services;
        }

    }
}
