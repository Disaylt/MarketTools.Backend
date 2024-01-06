﻿using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Queries.GetRange;
using MarketTools.Application.Interfaces.Excel;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard.RecommendationProducts
{
    [Route("api/v1/autoresponder/standard/recommendation-products/[controller]")]
    [ApiController]
    [Authorize]
    public class ExcelController(IMediator _mediator,
        IMapper _mapper,
        IExcelReader<StandardAutoresponderRecommendationProduct> _excelReader,
        IExcelWriter<StandardAutoresponderRecommendationProduct> _excelWriter)
        : ControllerBase
    {
        [HttpGet]
        [Route("excel")]
        public async Task<IActionResult> GetExcelAsync(MarketplaceName marketplaceName, CancellationToken cancellationToken)
        {
            GetRangeQuery query = new GetRangeQuery{ MarketplaceName = marketplaceName };

            IEnumerable<StandardAutoresponderRecommendationProduct> entites = await _mediator.Send(query, cancellationToken);
            Stream excelFile = _excelWriter.Write(entites);

            return File(excelFile, "application/octet-stream", "RecommendationTable.xlsx");
        }
    }
}