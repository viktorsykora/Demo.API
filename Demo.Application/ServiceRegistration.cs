using Demo.Application.Abstractions;
using Demo.Application.Features.GrossWrittenPremium;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IGrossWrittenPremiumCalculationService, GrossWrittenPremiumCalculationService>();
            return services;
        }
    }
}