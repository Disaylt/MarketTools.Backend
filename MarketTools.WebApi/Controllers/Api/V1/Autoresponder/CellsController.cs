﻿using MarketTools.Application.Cases.Autoresponder.Standard.Cells.Models;
using MarketTools.Application.Cases.Autoresponder.Standard.Cells.Queries.GetRange;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder
{
    [Route("api/v1/autoresponder/[controller]")]
    [ApiController]
    [Authorize]
    public class CellsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(int columnId, CancellationToken cancellationToken)
        {
            GetRangeQuery query = new GetRangeQuery { CollumnId = columnId };
            IEnumerable<CellVm> cells = await _mediator.Send(query, cancellationToken);

            return Ok(cells);
        }
    }
}
