using Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<GrossWrittenPremium> GrossWrittenPremiums { get; }        
    }
}
