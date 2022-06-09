using ManasApp.Services;
using ManasApp.Services.Contract.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ManasApp.WebAPI.Configurations
{
    public class DependencyConfig
    {
        public static IServiceCollection Configure(IServiceCollection services)
        {
            services.AddScoped<ILocalityService, LocalityService>();

            return services;
        }
    }
}
