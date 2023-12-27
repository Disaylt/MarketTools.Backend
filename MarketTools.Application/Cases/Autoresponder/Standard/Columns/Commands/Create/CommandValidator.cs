using FluentValidation;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Autoresponder.Standard.Models;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Columns.Commands.Create
{
    public class CommandValidator : AbstractValidator<CreateCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, IStandardAutoresponderLimitationsService standardAutoresponderLimitationsService)
        {
            RuleFor(x => x)
                .MustAsync(async (columnId, ct) =>
                {
                    StandardAutoresponderLimitsDto limits = await standardAutoresponderLimitationsService.GetAsync();
                    int totalColumns = await authUnitOfWork.StandardAutoresponderColumns.CountAsync();

                    return totalColumns < limits.MaxColumns;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит колонок.");
        }
    }
}
