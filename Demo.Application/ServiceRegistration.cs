using Demo.Application.Features.GrossWrittenPremium.Queries;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
            services.AddValidatorsFromAssemblyContaining<GetAveragePerCountryQuery>();
            return services;
        }
    }
}
