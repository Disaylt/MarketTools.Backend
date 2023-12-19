using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.Add;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Models;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder.Template;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard.Template
{
    [Route("api/v1/autoresponder/standard/template/[controller]")]
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
            AddCommand command = _mapper.Map<AddCommand>(body);
            ArticleVm result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            DefaultDeleteCommand<StandardAutoresponderTemplateArticle> command = new DefaultDeleteCommand<StandardAutoresponderTemplateArticle> { Id = id };
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}
