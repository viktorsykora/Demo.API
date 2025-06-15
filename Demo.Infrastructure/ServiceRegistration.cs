using Demo.Application.Abstractions;
using Demo.Infrastructure.Context;
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

            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }
}
