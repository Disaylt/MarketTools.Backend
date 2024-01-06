using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Queries.GetRange;
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
    public class TemplatesController(IMediator _mediator,
        IMapper _mapper)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderTemplate> templates = await _mediator.Send(new GetRangeQuery(), cancellationToken);
            IEnumerable<TemplateVm> viewTemplates = _mapper.Map<IEnumerable<TemplateVm>>(templates);

            return Ok(viewTemplates);
        }
    }
}
