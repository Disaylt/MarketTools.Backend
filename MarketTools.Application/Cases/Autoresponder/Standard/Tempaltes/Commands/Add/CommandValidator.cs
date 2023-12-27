using FluentValidation;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Autoresponder.Standard.Models;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Commands.Add
{
    public class CommandValidator : AbstractValidator<AddCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, IStandardAutoresponderLimitationsService standardAutoresponderLimitationsService)
        {
            RuleFor(x => x)
                .MustAsync(async (template, ct) =>
                {
                    StandardAutoresponderLimitsDto limits = await standardAutoresponderLimitationsService.GetAsync();
                    int totalTemplates = await authUnitOfWork.StandardAutoresponderTemplates.CountAsync();

                    return totalTemplates < limits.MaxTemplates;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит шаблонов.");
        }
    }
}
