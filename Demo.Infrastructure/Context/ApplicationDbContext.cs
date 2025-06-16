using Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<GrossWrittenPremium> GrossWrittenPremiums => Set<GrossWrittenPremium>();
    }
}