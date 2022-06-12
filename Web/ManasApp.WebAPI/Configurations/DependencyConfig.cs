using ManasApp.Data.Contract.Repositories;
using ManasApp.Data.Repositories;
using ManasApp.Services;
using ManasApp.Services.Contract.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ManasApp.WebAPI.Configurations
{
    public class DependencyConfig
    {
        public static IServiceCollection Configure(IServiceCollection services)
        {
            services.AddScoped<ILocalityRepository, LocalityRepository>();
            services.AddScoped<IMapRepository, MapRepository>();

            services.AddScoped<ILocalityService, LocalityService>();
            services.AddScoped<IMapService, MapService>();

            return services;
        }
    }
}
