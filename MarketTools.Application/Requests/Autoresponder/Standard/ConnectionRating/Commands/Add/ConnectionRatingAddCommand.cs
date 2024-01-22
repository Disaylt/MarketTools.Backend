using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.Add
{
    public class ConnectionRatingAddCommand
    {
        public int Rating { get; set; }
        public int ConnectionId { get; set; }
        public int TemplateId { get; set; }
    }
}
