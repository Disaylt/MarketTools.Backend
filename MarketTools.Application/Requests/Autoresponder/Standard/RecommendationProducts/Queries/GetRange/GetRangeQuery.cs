using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Queries.GetRange
{
    public class GetRangeQuery : IRequest<IEnumerable<StandardAutoresponderRecommendationProductEntity>>
    {
        public PageRequest? PageRequest { get; set; }
        public string? Article { get; set; }
        public MarketplaceName? MarketplaceName { get; set; }
    }
}
