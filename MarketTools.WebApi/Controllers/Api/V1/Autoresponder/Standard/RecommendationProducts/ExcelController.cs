﻿using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Queries.GetRange;
using MarketTools.Application.Interfaces.Excel;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands.AddRange;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.WebApi.Models.Api.Autoreponder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MarketTools.WebApi.Extensions;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands.ReplaceRange;

namespace MarketTools.WebApi.Controllers.Api.V1.Autoresponder.Standard.RecommendationProducts
{
    [Route("api/v1/autoresponder/standard/recommendation-products/[controller]")]
    [ApiController]
    [Authorize]
    public class ExcelController(IMediator _mediator,
        IMapper _mapper,
        IExcelReader<StandardAutoresponderRecommendationProductEntity> _excelReader,
        IExcelWriter<StandardAutoresponderRecommendationProductEntity> _excelWriter)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetExcelAsync(MarketplaceName marketplaceName, CancellationToken cancellationToken)
        {
            GetRangeQuery query = new GetRangeQuery{ MarketplaceName = marketplaceName };

            IEnumerable<StandardAutoresponderRecommendationProductEntity> entites = await _mediator.Send(query, cancellationToken);
            Stream excelFile = _excelWriter.Write(entites);

            return File(excelFile, "application/octet-stream", "RecommendationTable.xlsx");
        }

        [HttpPost]
        public async Task<IActionResult> AddRangeAsync([FromQuery] MarketplaceName marketplaceName, IFormFile file)
        {
            IEnumerable<StandardAutoresponderRecommendationProductEntity> entities = _excelReader.Read(file);
            AddRangeCommand addRangeCommand = new AddRangeCommand { Products = entities, MarketplaceName = marketplaceName };
            IEnumerable<StandardAutoresponderRecommendationProductEntity> newEntities = await _mediator.Send(addRangeCommand);

            IEnumerable<RecommendationProductVm> viewProducts = _mapper.Map<IEnumerable<RecommendationProductVm>>(newEntities);

            return Ok(viewProducts);
        }

        [HttpPut]
        public async Task<IActionResult> ReplaceRangeAsync([FromQuery] MarketplaceName marketplaceName, IFormFile file)
        {
            IEnumerable<StandardAutoresponderRecommendationProductEntity> entities = _excelReader.Read(file);
            ReplaceRangeCommand addRangeCommand = new ReplaceRangeCommand { Products = entities, MarketplaceName = marketplaceName };
            IEnumerable<StandardAutoresponderRecommendationProductEntity> newEntities = await _mediator.Send(addRangeCommand);

            IEnumerable<RecommendationProductVm> viewProducts = _mapper.Map<IEnumerable<RecommendationProductVm>>(newEntities);


            return Ok(viewProducts);
        }
    }
}
