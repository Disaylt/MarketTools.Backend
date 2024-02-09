using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Connections.Commands.UpdateStatus
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork,
        IConnectionServiceFactory<IServiceValidator> _connectionServiceFactory,
        IUserNotificationsService _userNotificationsService)
        : IRequestHandler<UpdateConnenctionStatusCommand, Unit>
    {
        private readonly IRepository<StandardAutoresponderConnectionEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderConnectionEntity>();
        IRepository<MarketplaceConnectionEntity> _connectionRepository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();

        public async Task<Unit> Handle(UpdateConnenctionStatusCommand request, CancellationToken cancellationToken)
        {
            if (request.IsActive)
            {
                await CheckConnection(request.Id);
            }

            StandardAutoresponderConnectionEntity entity = await _repository.FirstAsync(x => x.SellerConnectionId == request.Id, cancellationToken);

            entity.IsActive = request.IsActive;

            _repository.Update(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task AddNotification(UpdateConnenctionStatusCommand request)
        {

        }

        private async Task CheckConnection(int id)
        {
            MarketplaceConnectionEntity entity = await _connectionRepository.FirstAsync(x => x.Id == id);

            await _connectionServiceFactory.Create(entity.MarketplaceName)
                .Create(EnumProjectServices.StandardAutoresponder)
                .TryActivete(id);
        }
    }
}
