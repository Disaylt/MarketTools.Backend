using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Queries.GetRange
{
    public class GetRangeRatingsQuery : IRequest<IEnumerable<StandardAutoresponderConnectionRatingEntity>>
    {
        public int ConnectionId { get; set; }
    }
}
