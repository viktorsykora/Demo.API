using Demo.Application.Abstractions;
using Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Context
{
    internal class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<GrossWrittenPremium> GrossWrittenPremiums => Set<GrossWrittenPremium>();
    }
}