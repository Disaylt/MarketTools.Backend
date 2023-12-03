using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigsController(IConfiguration _configuration) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_configuration.AsEnumerable());
        }
    }
}
