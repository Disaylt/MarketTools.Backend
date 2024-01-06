using AutoMapper;
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
        public IActionResult AddRangeAsync([FromQuery] MarketplaceName marketplaceName, IFormFile formFile)
        {
            IEnumerable<StandardAutoresponderRecommendationProductEntity> entities = GetFromExcel(formFile);


            return Ok();
        }

        [HttpPut]
        public IActionResult ReplaceRangeAsync([FromQuery] MarketplaceName marketplaceName, IFormFile formFile)
        {
            IEnumerable<StandardAutoresponderRecommendationProductEntity> entities = GetFromExcel(formFile);


            return Ok();
        }

        private IEnumerable<StandardAutoresponderRecommendationProductEntity> GetFromExcel(IFormFile formFile)
        {
            Stream stream = formFile.OpenReadStream();

            return _excelReader.Read(stream);
        }
    }
}
