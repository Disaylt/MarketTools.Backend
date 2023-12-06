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
        [Required(ErrorMessage = "Введите почту")]
        public required string Email { get; set; }

        [Required(ErrorMessage ="Введите пароль")]
        [Length(6,30, ErrorMessage ="Введите от 6 до 30 символов")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Length(6, 30, ErrorMessage = "Введите от 6 до 30 символов")]
        public required string RepeatPassword { get; set; }
    }
}
