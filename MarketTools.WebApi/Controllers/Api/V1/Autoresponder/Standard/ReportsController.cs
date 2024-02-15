using AutoMapper;
using MarketTools.Application.Requests.Autoresponder.Standard.Reports.Queries;
using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using MarketTools.WebApi.Models.Api.Autoreponder.Standard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard
{
    [Route("api/v1/autoresponder/standard/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportsController(IMediator _mediator, IMapper _mapper)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRangeAsync([FromQuery] ReportQueryDto httpQuery)
        {
            IEnumerable<ReportVm> viewReports = await GetViewReports(httpQuery);
            int total = await CountTotalAsync(httpQuery);

            PageResult<ReportVm> pageResult = new PageResult<ReportVm>(total, viewReports);

            return Ok(pageResult);
        }

        private async Task<int> CountTotalAsync(ReportQueryDto httpQuery)
        {
            CountReportsQuery query = _mapper.Map<CountReportsQuery>(httpQuery);

            return await _mediator.Send(query);
        }

        private async Task<IEnumerable<ReportVm>> GetViewReports(ReportQueryDto httpQuery)
        {
            GetRangeReportsQuery query = _mapper.Map<GetRangeReportsQuery>(httpQuery);

            IEnumerable<StandardAutoresponderNotificationEntity> reports = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<ReportVm>>(reports);
        }
    }
}
