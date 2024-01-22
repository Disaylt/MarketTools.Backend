using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Connections.Commands.UpdateStatus
{
    public class UpdateConnenctionStatusCommand : IRequest
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
