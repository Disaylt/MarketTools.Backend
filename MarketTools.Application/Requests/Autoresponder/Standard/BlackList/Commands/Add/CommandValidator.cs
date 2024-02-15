using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.Commands.Add
{
    public class CommandValidator : AbstractValidator<BlackListAddCommand>
    {
        public CommandValidator(ILimitsService<IStandarAutoresponderLimits> limitsService, IAuthUnitOfWork authUnitOfWork) 
        {
            RuleFor(x => x)
                .MustAsync(async (x, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalBlackLists = await authUnitOfWork.GetRepository<StandardAutoresponderBlackListEntity>()
                        .CountAsync(ct);

                    return totalBlackLists < limits.MaxBlackList;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит черных списков.");
        }
    }
}
