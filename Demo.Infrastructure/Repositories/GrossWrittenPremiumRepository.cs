using Demo.Application.Abstractions;
using Demo.Domain;
using Demo.Infrastructure.Context;
using Demo.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Repositories
{
    internal class GrossWrittenPremiumRepository : IGrossWrittenPremiumRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GrossWrittenPremiumRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GrossWrittenPremium[]> GrossWrittenPremiumsByCountryAndYear(Country country, 
            int yearSince, int yearUntil, LineOfBusiness[] lineOfBusinesses)
        {
            return await _dbContext.GrossWrittenPremiums
                .Where(g => g.Year >= yearSince &&
                            g.Year <= yearUntil &&
                            lineOfBusinesses.Contains(g.LineOfBusiness) &&
                            g.Country == country)
                .ToArrayAsync();
        }
    }
}
