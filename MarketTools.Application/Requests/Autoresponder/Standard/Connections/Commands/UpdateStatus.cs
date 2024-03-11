using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Interfaces.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Connections.Commands
{
    public class UpdateConnenctionStatusCommand : IRequest<Unit>, IHttpConnectionContextCall, IConnectionContextCall
    {
        public bool IsActive { get; set; }
        public int ConnectionId { get; set; }
    }

    public class UpdateStatusCommandHandler(IAuthUnitOfWork _authUnitOfWork,
        IContextService<MarketplaceConnectionEntity> _connectionContextService,
        IProjectServiceFactory<IProjectServiceValidator> _connectionServiceFactory,
        IUserNotificationsService _userNotificationsService)
        : IRequestHandler<UpdateConnenctionStatusCommand, Unit>
    {
        private readonly IRepository<StandardAutoresponderConnectionEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderConnectionEntity>();

        public async Task<Unit> Handle(UpdateConnenctionStatusCommand request, CancellationToken cancellationToken)
        {
            if (request.IsActive)
            {
                await _connectionServiceFactory
                    .Create(EnumProjectServices.StandardAutoresponder)
                    .TryActivate(_connectionContextService.Context);
            }

            StandardAutoresponderConnectionEntity serviceConnection = await _repository.FirstAsync(x => x.SellerConnectionId == request.ConnectionId, cancellationToken);

            serviceConnection.IsActive = request.IsActive;

            _repository.Update(serviceConnection);
            await AddNotificationAsync( serviceConnection);
            await _authUnitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task AddNotificationAsync(StandardAutoresponderConnectionEntity entity)
        {
            string status = entity.IsActive ? "Активирован" : "Отключен";
            string message = $"Стандартный автоответчик - {status}. Подключение: {_connectionContextService.Context.Name}. Маркетплейс: {MarketplaceNameConverter.Convert(_connectionContextService.Context.MarketplaceName)}";

            await _userNotificationsService.AddAsync(message);
        }
    }
}
