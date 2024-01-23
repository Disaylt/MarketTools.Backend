using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.Add
{
    public class CommandValidator : AbstractValidator<AddRatingCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork) 
        {
            RuleFor(x => x.ConnectionId)
                .MustAsync(async (connectionId, ct) =>
                {
                    return await authUnitOfWork.SellerConnections
                        .AnyAsync(x => x.Id == connectionId, ct);
                })
                .WithErrorCode("404")
                .WithMessage("Подключение не найдено.");
        }
    }
}
