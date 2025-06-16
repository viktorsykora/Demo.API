using Demo.Application.Abstractions;
using Demo.Infrastructure.Context;
using Demo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(nameof(ApplicationDbContext)));

            services.AddTransient<ApplicationDbContext>();
            services.AddTransient<IGrossWrittenPremiumRepository, GrossWrittenPremiumRepository>();

            return services;
        }
    }
}
