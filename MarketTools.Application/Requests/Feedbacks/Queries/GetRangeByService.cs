using MarketTools.Application.Interfaces.Feedbacks;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Feedbacks;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Feedbacks.Queries
{
    public class GetRangeFeedbacksByServiceQuery : IRequest<IEnumerable<FeedbackDto>>
    {
        public EnumProjectServices Service { get; set; }
        public MarketplaceName MarketplaceName { get; set; }
        public required FeedbacksQueryDto Params { get; set; }
    }

    public class QueryHandler(IConnectionServiceFactory<IFeedbacksService> _feedbacksServiceFactory, 
        IConnectionDefinitionService _connectionDefinitionService)
        : IRequestHandler<GetRangeFeedbacksByServiceQuery, IEnumerable<FeedbackDto>>
    {
        public async Task<IEnumerable<FeedbackDto>> Handle(GetRangeFeedbacksByServiceQuery request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionType connectionType = _connectionDefinitionService.Get(request.MarketplaceName, request.Service);

            return await _feedbacksServiceFactory
                .Create(connectionType, request.MarketplaceName)
                .GetFeedbacksAsync(request.Params);
        }
    }
}
