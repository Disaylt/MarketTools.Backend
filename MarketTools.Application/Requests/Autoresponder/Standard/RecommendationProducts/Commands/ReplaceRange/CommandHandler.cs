using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands.ReplaceRange
{
    public class CommandHandler
        : IRequestHandler<ReplaceRangeCommand, IEnumerable<StandardAutoresponderRecommendationProductEntity>>
    {
        public Task<IEnumerable<StandardAutoresponderRecommendationProductEntity>> Handle(ReplaceRangeCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
