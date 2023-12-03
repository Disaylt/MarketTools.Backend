using MarketTools.Application.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MarketTools.WebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SequreConfigsController(IOptions<SequreSettings> _sequreOptions) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_sequreOptions.Value);
        }
    }
}
