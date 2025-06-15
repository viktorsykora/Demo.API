using Demo.Application.Abstractions;
using Demo.Shared.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Features.GrossWrittenPremium.Queries
{
    public class GetAveragePerCountryQueryHandler : IRequestHandler<GetAveragePerCountryQuery, Dictionary<LineOfBusiness, decimal>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAveragePerCountryQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Dictionary<LineOfBusiness, decimal>> Handle(GetAveragePerCountryQuery request, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.GrossWrittenPremiums
                .Where(g => g.Year >= request.YearSince &&
                            g.Year <= request.YearUntil &&
                            request.LinesOfBusiness.Contains(g.LineOfBusiness) &&
                            g.Country == request.Country)
                .GroupBy(g => g.LineOfBusiness)
                .Select(group => new
                {
                    LineOfBusiness = group.Key,
                    Average = group.Average(g => g.Amount)
                })
                .ToDictionaryAsync(
                g => g.LineOfBusiness,
                g => g.Average,
                cancellationToken);
        }
    }
}
