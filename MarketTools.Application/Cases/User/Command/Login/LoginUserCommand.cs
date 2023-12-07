using MarketTools.Application.Cases.User.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.User.Command.Login
{
    public class LoginUserCommand : IRequest<TokenVm>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
