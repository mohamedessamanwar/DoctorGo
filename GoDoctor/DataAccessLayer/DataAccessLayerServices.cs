using DataAccessLayer.Data.Context;
using DataAccessLayer.UnitOfWorkRepo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DataAccessLayerServices
    {
        public static IServiceCollection DataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
