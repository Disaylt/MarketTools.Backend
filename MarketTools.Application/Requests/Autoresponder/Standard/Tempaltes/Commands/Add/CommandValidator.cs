using FluentValidation;
using MarketTools.Application.Interfaces;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Commands.Add
{
    public class CommandValidator : AbstractValidator<TemplateAddCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService)
        {
            IRepository<StandardAutoresponderTemplateEntity> repository = authUnitOfWork.GetRepository<StandardAutoresponderTemplateEntity>();

            RuleFor(x => x)
                .MustAsync(async (template, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalTemplates = await repository.CountAsync();

                    return totalTemplates < limits.MaxTemplates;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит шаблонов.");
        }
    }
}
