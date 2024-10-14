using BusinessAccessLayer.Services.Email;
using BusinessAccessLayer.Services.PaymentService;
using BusinessAccessLayer.Sevices.AppointmentService;
using BusinessAccessLayer.Sevices.AuthService;
using BusinessAccessLayer.Sevices.BookingService;
using BusinessAccessLayer.Sevices.CommentService;
using BusinessAccessLayer.Sevices.DoctorService;
using BusinessAccessLayer.Sevices.SpecialtyService;
using BusinessAccessLayer.Sevices.TimeSlotService;
using DataAccessLayer.Repositories.BookingRepo;
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
            services.AddScoped<IPayment, StripPayment>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped< ICommentService ,CommentService>();
            services.AddTransient<IMailingService, MailingService>();
           // services.Configure<MailSetting>(configuration.GetSection("MailSetting"));
            return services;
        }

    }
}
