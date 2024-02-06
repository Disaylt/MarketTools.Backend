using MarketTools.Application.Models.Autoresponder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Response.Command.Create
{
    public class CreateResponseCommand : IRequest<AutoresponderResultModel>
    {
        public int ConnectionId { get; set; }
        public required string Article { get; set; }
        public required string Text { get; set; }
        public int Rating { get; set; }
    }
}
