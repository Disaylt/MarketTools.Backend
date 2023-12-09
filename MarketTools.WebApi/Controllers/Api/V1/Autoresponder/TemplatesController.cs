﻿using MarketTools.Application.Cases.Autoresponder.Tempaltes.Models;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder
{
    [Route("api/v1/autoresponder/[controller]")]
    [ApiController]
    [Authorize]
    public class TemplatesController(IMediator _mediator)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            IEnumerable<TemplateVm> result = await _mediator.Send(new GetTemplatesListQuery(), cancellationToken);

            return Ok(result);
        }
    }
}