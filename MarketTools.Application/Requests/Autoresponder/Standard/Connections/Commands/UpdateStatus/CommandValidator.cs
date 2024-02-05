using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Connections.Commands.UpdateStatus
{
    public class CommandValidator : AbstractValidator<UpdateConnenctionStatusCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, IConnectionServiceFactory<IServiceValidator> connectionServiceFactory) 
        {
            IRepository<MarketplaceConnectionEntity> connectionRepository = authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();
            RuleFor(x => x)
                .MustAsync(async (value, ct) =>
                {
                    if (value.IsActive == false)
                    {
                        return true;
                    }

                    MarketplaceConnectionEntity entity = await connectionRepository.FirstAsync(x=> x.Id == value.Id);

                    await connectionServiceFactory.Create(entity.MarketplaceName)
                        .Create(EnumProjectServices.StandardAutoresponder)
                        .TryActivete(value.Id);

                    return true;
                })
                .WithErrorCode("400")
                .WithMessage("Не удалось получить отзывы, проверьте токен или попробуйте позже.");
        }
    }
}
