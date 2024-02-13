using MarketTools.Application.Cases.User.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.User.Command.Register
{
    public class RegisterUserCommand : IRequest<TokenVm>
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string RepeatPassword { get; set; }
    }
}
