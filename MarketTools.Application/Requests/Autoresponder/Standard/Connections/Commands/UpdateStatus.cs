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

namespace MarketTools.Application.Requests.Autoresponder.Standard.Connections.Commands
{
    public class UpdateConnenctionStatusCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateStatusCommandHandler(IAuthUnitOfWork _authUnitOfWork,
        IProjectServiceFactory<IServiceValidator> _connectionServiceFactory,
        IUserNotificationsService _userNotificationsService)
        : IRequestHandler<UpdateConnenctionStatusCommand, Unit>
    {
        private readonly IRepository<StandardAutoresponderConnectionEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderConnectionEntity>();
        IRepository<MarketplaceConnectionEntity> _connectionRepository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();

        public async Task<Unit> Handle(UpdateConnenctionStatusCommand request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionEntity marketplaceConnection = await _connectionRepository.FirstAsync(x => x.Id == request.Id);

            if (request.IsActive)
            {
                await CheckConnection(marketplaceConnection);
            }

            StandardAutoresponderConnectionEntity serviceConnection = await _repository.FirstAsync(x => x.SellerConnectionId == request.Id, cancellationToken);

            serviceConnection.IsActive = request.IsActive;

            _repository.Update(serviceConnection);
            await AddNotificationAsync(marketplaceConnection, serviceConnection);
            await _authUnitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task AddNotificationAsync(MarketplaceConnectionEntity marketplaceConnection, StandardAutoresponderConnectionEntity entity)
        {
            string status = entity.IsActive ? "Активирован" : "Отключен";
            string message = $"Стандартный автоответчик - {status}. Подключение: {marketplaceConnection.Name}. Маркетплейс: {MarketplaceNameConverter.Convert(marketplaceConnection.MarketplaceName)}";

            await _userNotificationsService.AddAsync(message);
        }

        private async Task CheckConnection(MarketplaceConnectionEntity entity)
        {
            await _connectionServiceFactory.Create(EnumProjectServices.StandardAutoresponder)
                .Create(entity.MarketplaceName)
                .TryActivete(entity.Id);
        }
    }
}
