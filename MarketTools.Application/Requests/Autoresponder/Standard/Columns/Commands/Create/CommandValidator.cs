using FluentValidation;
using MarketTools.Application.Interfaces;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Columns.Commands.Create
{
    public class CommandValidator : AbstractValidator<ColumnCreateCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService)
        {
            RuleFor(x => x)
                .MustAsync(async (columnId, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalColumns = await authUnitOfWork.StandardAutoresponderColumns.CountAsync();

                    return totalColumns < limits.MaxColumns;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит колонок.");
        }
    }
}
