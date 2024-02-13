using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Command.UpdateDescription
{
    public class MpConnectionUpdateDescriptionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }
}
