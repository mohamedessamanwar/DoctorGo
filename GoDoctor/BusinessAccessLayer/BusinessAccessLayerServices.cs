using BusinessAccessLayer.Sevices.AuthService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BusinessAccessLayer

{
    public static class BusinessAccessLayerServices
    {
        public static IServiceCollection BusinessAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

    }
}
