using Demo.Shared.Enums;

namespace Demo.Application.Abstractions
{
    public interface IGrossWrittenPremiumCalculationService
    {
        Task<Dictionary<LineOfBusiness, decimal>> GetAveragePerCountry(Country country, LineOfBusiness[] linesOfBusiness,
            int yearSince, int yearUntil);
    }
}
