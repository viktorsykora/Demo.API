using Demo.Application.Abstractions;
using Demo.Shared.Enums;

namespace Demo.Application.Features.GrossWrittenPremium
{
    public class GrossWrittenPremiumCalculationService : IGrossWrittenPremiumCalculationService
    {
        private readonly IGrossWrittenPremiumRepository _grossWrittenPremiumRepository;

        public GrossWrittenPremiumCalculationService(IGrossWrittenPremiumRepository grossWrittenPremiumRepository)
        {
            _grossWrittenPremiumRepository = grossWrittenPremiumRepository;
        }

        public async Task<Dictionary<LineOfBusiness, decimal>> GetAveragePerCountry(Country country, LineOfBusiness[] linesOfBusiness, 
            int yearSince, int yearUntil)
        {
            var premiums = await _grossWrittenPremiumRepository.GrossWrittenPremiumsByCountryAndYear(country, yearSince, yearUntil, linesOfBusiness);
            return premiums
                .GroupBy(g => g.LineOfBusiness)
                .ToDictionary(
                    group => group.Key,
                    group => group.Average(g => g.Amount));
        }
    }
}
