using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Models;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands.ReplaceRange
{
    public class ReplaceRangeCommand : RangeCommand, IRequest<IEnumerable<StandardAutoresponderRecommendationProductEntity>>
    {
        
    }
}
