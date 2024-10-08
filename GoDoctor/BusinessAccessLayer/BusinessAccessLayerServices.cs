﻿using BusinessAccessLayer.Sevices.AppointmentService;
using BusinessAccessLayer.Sevices.AuthService;
using BusinessAccessLayer.Sevices.DoctorService;
using BusinessAccessLayer.Sevices.SpecialtyService;
using BusinessAccessLayer.Sevices.TimeSlotService;
using DataAccessLayer.Repositories.SpecialtyRepo;
using DataAccessLayer.Repositories.TimeSlotRepo;
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
            services.AddScoped<ITimeSlotService, TimeSlotService>();
            return services;
        }

    }
}
