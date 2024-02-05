using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Connections.Commands.UpdateStatus
{
    public class CommandValidator : AbstractValidator<UpdateConnenctionStatusCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, IConnectionServiceFactory<IServiceValidator> connectionServiceFactory) 
        {
            Console.WriteLine("asd");
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
                });
        }
    }
}
