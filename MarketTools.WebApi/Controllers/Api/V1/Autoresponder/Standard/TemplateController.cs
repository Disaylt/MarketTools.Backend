﻿using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Commands.Add;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Models;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/[controller]")]
    [ApiController]
    [Authorize]
    public class TemplateController(IMediator _mediator,
        IMapper _mapper)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TemplateCreateDto body, CancellationToken ct)
        {
            AddCommand command = _mapper.Map<AddCommand>(body);
            TemplateVm result = await _mediator.Send(command, ct);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken ct)
        {
            DefaultDeleteCommand<StandardAutoresponderTemplate> command = new DefaultDeleteCommand<StandardAutoresponderTemplate> { Id = id };
            await _mediator.Send(command, ct);

            return Ok();
        }
    }
}