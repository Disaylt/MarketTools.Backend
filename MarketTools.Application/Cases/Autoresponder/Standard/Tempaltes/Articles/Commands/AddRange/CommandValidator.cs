using FluentValidation;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Validatiors;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.AddRange
{
    public class CommandValidator : TemplateInteractValidator<AddRangeCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork) : base(authUnitOfWork)
        {
            RuleFor(x => x.Articles)
                .Must(x => x.Count() > 1500)
                .WithMessage("Невозможно добавить более 1500 артикулов за 1 раз.");
        }
    }
}
