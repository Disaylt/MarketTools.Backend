﻿using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestsController(IAutoresponderContextService autoresponderContextService)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var test = await autoresponderContextService.CreateAsync(id);

            return Ok();
        }
    }
}
