﻿using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Commands.Add;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Models;
using MarketTools.WebApi.Models.Autoreponder.Template;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Template
{
    [Route("api/v1/autoresponder/template/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleController
        (IMapper _mapper,
        IMediator _mediator)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ArticleCreateDto body, CancellationToken cancellationToken)
        {
            AddArticleCommand command = _mapper.Map<AddArticleCommand>(body);
            ArticleVm result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}