using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Commands.DeleteAll;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Models;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Template
{
    [Route("api/v1/autoresponder/template/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticlesController
        (IMediator _mediator)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(int templateId)
        {
            GetArticlesQuery query = new GetArticlesQuery { TemplateId = templateId };
            IEnumerable<ArticleVm> result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete]
        [Route("all")]
        public async Task<IActionResult> DeleteAsync(int templateId)
        {
            DeleteAllCommand command = new DeleteAllCommand {  TemplateId = templateId };
            await _mediator.Send(command);

            return Ok();
        }
    }
}
