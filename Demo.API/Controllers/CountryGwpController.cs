using Demo.API.Dtos;
using Demo.Application.Features.GrossWrittenPremium.Queries;
using Demo.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [ApiController]
    [Route("server/api/gwp")]
    public class CountryGwpController : Controller
    {
        private readonly IMediator _mediator;

        public CountryGwpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("avg")]
        public async Task<Dictionary<LineOfBusiness, decimal>> Average([FromBody] GetAverageGrossWrittenPremiumDto requestDto)
        {
            return await _mediator.Send(new GetAveragePerCountryQuery
            {
                Country = requestDto.Country,
                LinesOfBusiness = requestDto.Lob,
                YearSince = 2008,
                YearUntil = 2015
            });
        }
    }
}
