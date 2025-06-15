using Demo.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [ApiController]
    [Route("server/api/[controller]")]
    public class CountryGwpController : Controller
    {
        [HttpPost("avg")]
        public async Task<Dictionary<LineOfBusiness, decimal>> Average([FromBody] GetAvgDto createTodoCommand)
        {
            //var id = await _mediator.Send(createTodoCommand);
            //return CreatedAtAction(nameof(GetById), new { id }, createTodoCommand);
            return null;
        }
    }
}
