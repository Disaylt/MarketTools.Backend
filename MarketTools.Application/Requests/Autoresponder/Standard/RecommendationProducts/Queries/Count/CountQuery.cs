using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Queries.Count
{
    public class CountQuery : IRequest<int>
    {
        public string? Article { get; set; }
        public MarketplaceName? MarketplaceName { get; set; }
    }
}
