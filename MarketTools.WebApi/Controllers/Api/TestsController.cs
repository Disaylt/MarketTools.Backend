using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Wb.Seller.Api;
using MarketTools.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestsController()
        : ControllerBase
    {
    }
}
