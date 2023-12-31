﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.User.Command.Register
{
    public class CommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public CommandValidator() 
        {
            RuleFor(x => x.Password)
                .Equal(x => x.RepeatPassword)
                .WithMessage(x => "Пароли не совпадают");
        }
    }
}
