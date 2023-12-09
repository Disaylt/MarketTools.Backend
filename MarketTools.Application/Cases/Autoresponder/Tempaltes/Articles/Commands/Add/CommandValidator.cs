using FluentValidation;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Models;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Validations;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Commands.Add
{
    public class CommandValidator : AddCommandValidator<AddArticleCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork) : base(authUnitOfWork)
        {
            
        }
    }
}
