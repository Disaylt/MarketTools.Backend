using MarketTools.Application.Cases.User.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.User.Command.Register
{
    internal class CommandHandler : IRequestHandler<RegisterUserCommand, TokenVm>
    {

        public Task<TokenVm> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
