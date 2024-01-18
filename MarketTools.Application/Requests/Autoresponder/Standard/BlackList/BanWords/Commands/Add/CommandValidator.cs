using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.BanWords.Commands.Add
{
    public class CommandValidator : AbstractValidator<BanWordAddCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork) 
        {
            RuleFor(x => x.BlackListId)
                .MustAsync(async (blackListId, ct) =>
                {
                    StandardAutoresponderBlackListEntity? entity = await authUnitOfWork.StandardAutoresponderBlackLists
                        .FirstOrDefaultAsync(x=> x.Id == blackListId);

                    return entity != null;
                })
                .WithErrorCode("404")
                .WithMessage("Черынй список не найден.");
        }
    }
}
