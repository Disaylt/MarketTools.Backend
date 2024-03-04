using AutoMapper;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Wb;
using MarketTools.Application.Interfaces.Http.Wb.Seller;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Http.WB.Seller;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Feedabacks.Queires
{
    public class GetRangeWbFeedbacksQuery : IRequest<IEnumerable<FeedbackDto>>, IHasMap
    {
        public required bool IsAnswered { get; set; }
        public required int Take { get; set;}
        public required int Skip { get; set;}
        public required string Order { get; set; }
        public int? NmId { get; set; }
        public int? DateFrom { get; set; }
        public int? DateTo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetRangeWbFeedbacksQuery, FeedbacksGetDto>();
        }
    }

    public class GetRangeWbFeedbacksHandler
        : IRequestHandler<GetRangeWbFeedbacksQuery, IEnumerable<FeedbackDto>>
    {
        private readonly IWbSellerFeedbacksHttpService _wbSellerFeedbacksHttpService;
        private readonly IMapper _mapper;

        public GetRangeWbFeedbacksHandler(IWbHttpRequestFactory<IWbSellerFeedbacksHttpService> _wbHttpRequestFactory,
            IProjectServiceFactory<IConnectionDefinitionService> _connectionDefinitionServiceFactory,
            IMapper mapper)
        {
            MarketplaceConnectionType marketplaceConnectionType = _connectionDefinitionServiceFactory
                .Create(EnumProjectServices.StandardAutoresponder, MarketplaceName.WB)
                .Get();

            _wbSellerFeedbacksHttpService = _wbHttpRequestFactory.Create(marketplaceConnectionType);
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeedbackDto>> Handle(GetRangeWbFeedbacksQuery request, CancellationToken cancellationToken)
        {
            FeedbacksGetDto httpQuery = _mapper.Map<FeedbacksGetDto>(request);

            return await _wbSellerFeedbacksHttpService.GetFeedbacksAsync(httpQuery);
        }
    }
}
