using Demo.API.Dtos;
using Demo.Application.Abstractions;
using Demo.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [ApiController]
    [Route("server/api/gwp")]
    public class CountryGwpController : Controller
    {
        private readonly IGrossWrittenPremiumCalculationService _grossWrittenPremiumCalculationService;

        public CountryGwpController(IGrossWrittenPremiumCalculationService grossWrittenPremiumCalculationService)
        {
            _grossWrittenPremiumCalculationService = grossWrittenPremiumCalculationService;
        }

        [HttpPost("avg")]
        public async Task<Dictionary<LineOfBusiness, decimal>> Average([FromBody] GetAverageGrossWrittenPremiumDto requestDto)
        {
            return await _grossWrittenPremiumCalculationService.GetAveragePerCountry(requestDto.Country, requestDto.Lob, 2008, 2015);
        }
    }
}
