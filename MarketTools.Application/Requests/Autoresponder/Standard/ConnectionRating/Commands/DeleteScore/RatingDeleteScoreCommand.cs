using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.DeleteScore
{
    public class RatingDeleteScoreCommand : IRequest
    {
        public int Rating { get; set; }
        public int ConnectionId { get; set; }
    }
}
