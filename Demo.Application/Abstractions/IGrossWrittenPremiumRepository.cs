using Demo.Domain;
using Demo.Shared.Enums;

namespace Demo.Application.Abstractions
{
    public interface IGrossWrittenPremiumRepository
    {
        Task<GrossWrittenPremium[]> GrossWrittenPremiumsByCountryAndYear(Country country,
            int yearSince, int yearUntil, LineOfBusiness[] lineOfBusinesses);
    }
}
