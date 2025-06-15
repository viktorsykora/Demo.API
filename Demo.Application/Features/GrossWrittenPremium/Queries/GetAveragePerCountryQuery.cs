using Demo.Shared.Enums;
using MediatR;

namespace Demo.Application.Features.GrossWrittenPremium.Queries
{
    public class GetAveragePerCountryQuery : IRequest<Dictionary<LineOfBusiness, decimal>>
    {
        public required Country Country { get; init; }
        public required LineOfBusiness[] LinesOfBusiness { get; init; }
        public required int YearSince { get; init; }
        public required int YearUntil { get; init; }
    }
}
