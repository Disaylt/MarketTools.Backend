using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Settings.Commands.Update
{
    public class CommandHandler : IRequestHandler<UpdateCommand>
    {
        public Task Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
