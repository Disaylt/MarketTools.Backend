using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.DeleteAll;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Models;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Queries.GetList;
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
    public class ArticlesController
        (IMediator _mediator, IMapper _mapper)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(int templateId)
        {
            ArticleGetArticlesQuery query = new ArticleGetArticlesQuery { TemplateId = templateId };
            IEnumerable<StandardAutoresponderTemplateArticleEntity> articles = await _mediator.Send(query);

            IEnumerable<ArticleVm> viewArticles = _mapper.Map<IEnumerable<ArticleVm>>(articles);

            return Ok(viewArticles);
        }

        [HttpDelete]
        [Route("all")]
        public async Task<IActionResult> DeleteAsync(int templateId)
        {
            ArticleDeleteAllCommand command = new ArticleDeleteAllCommand { TemplateId = templateId };
            await _mediator.Send(command);

            return Ok();
        }
    }
}
