using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands.AddRange
{
    public class AddRangeCommand : IRequest<IEnumerable<StandardAutoresponderRecommendationProductEntity>>
    {
        public required IEnumerable<StandardAutoresponderRecommendationProductEntity> Products { get; set; }
        public MarketplaceName MarketplaceName { get; set; }
    }
}
