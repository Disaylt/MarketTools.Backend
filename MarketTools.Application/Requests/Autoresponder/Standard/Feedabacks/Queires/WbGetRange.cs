using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Wb;
using MarketTools.Application.Interfaces.Http.Wb.Seller;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Http.WB.Seller;
using MarketTools.Application.Utilities.HttpParamsBuilder.WB.Seller;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Interfaces.Http;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Feedabacks.Queires
{
    public class GetRangeWbFeedbacksQuery : IRequest<IEnumerable<FeedbackDto>>
    {
        public required bool IsAnswered { get; set; }
        public required int Take { get; set;}
        public required int Skip { get; set;}
        public required string Order { get; set; }
        public int? NmId { get; set; }
        public int? DateFrom { get; set; }
        public int? DateTo { get; set; }
    }

    public class GetRangeWbFeedbacksHandler
        : IRequestHandler<GetRangeWbFeedbacksQuery, IEnumerable<FeedbackDto>>
    {
        private readonly IWbSellerFeedbacksHttpService _wbSellerFeedbacksHttpService;
        private readonly IHttpResponseConverter<IEnumerable<FeedbackDto>> _httpResponseConverter;

        public GetRangeWbFeedbacksHandler(IWbHttpRequestFactory<IWbSellerFeedbacksHttpService> _wbHttpRequestFactory,
            IHttpResponseConverterFactory<IWbSellerFeedbacksHttpService, IEnumerable<FeedbackDto>> _httpResponseConverterFactory,
            IProjectServiceFactory<IConnectionDefinitionService> _connectionDefinitionServiceFactory)
        {
            MarketplaceConnectionType marketplaceConnectionType = _connectionDefinitionServiceFactory
                .Create(EnumProjectServices.StandardAutoresponder, MarketplaceName.WB)
                .Get();

            _wbSellerFeedbacksHttpService = _wbHttpRequestFactory.Create(marketplaceConnectionType);
            _httpResponseConverter = _httpResponseConverterFactory.Create(marketplaceConnectionType);
        }

        public async Task<IEnumerable<FeedbackDto>> Handle(GetRangeWbFeedbacksQuery request, CancellationToken cancellationToken)
        {
            IParamsBuilder paramsBuilder = CreateParamsBuilder(request);
            HttpResponseMessage httpResponse = await _wbSellerFeedbacksHttpService.GetFeedbacksAsync(paramsBuilder);
            return await _httpResponseConverter.ConvertAsync(httpResponse);
        }

        private IParamsBuilder CreateParamsBuilder(GetRangeWbFeedbacksQuery request)
        {
            return new WbSellerGetFeedbacksParamBuilder()
                .IsAnswered(request.IsAnswered)
                .Take(request.Take)
                .Skip(request.Skip)
                .DateFrom(request.DateFrom)
                .DateTo(request.DateTo)
                .NmId(request.NmId)
                .Order(request.Order);
        }
    }
}
