using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Command.SellerOpenApi
{
    [Obsolete]
    public class OpenApiRefreshTokenCommand : IRequest<MarketplaceConnectionEntity>, IConnectionContextCall
    {
        public int Id { get; set; }
        public required string Token { get; set; }
        public int ConnectionId
        {
            get { return Id; }
            set { Id = value; }
        }
    }

    [Obsolete]
    public class RefreshTokenCommandHandler(IAuthUnitOfWork _authUnitOfWork,
        IUserNotificationsService _userNotificationsService,
        IContextService<MarketplaceConnectionEntity> _connectionContextService)
        : IRequestHandler<OpenApiRefreshTokenCommand, MarketplaceConnectionEntity>
    {

        private readonly IRepository<MarketplaceConnectionEntity> _repository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();

        public async Task<MarketplaceConnectionEntity> Handle(OpenApiRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            ChangeProperties(request);

            _repository.Update(_connectionContextService.Context);

            await _userNotificationsService.AddAsync($"Измение токена для API '{_connectionContextService.Context.Name}'. Маркетплейс: {_connectionContextService.Context.MarketplaceName}");

            await _authUnitOfWork.CommitAsync(cancellationToken);

            return _connectionContextService.Context;
        }

        private void ChangeProperties(OpenApiRefreshTokenCommand request)
        {
            _connectionContextService.Context.NumConnectionsAttempt = 0;

            if (string.IsNullOrEmpty(request.Token))
            {
                _connectionContextService.Context.IsActive = false;
            }
            else
            {
                _connectionContextService.Context.IsActive = true;
            }
        }
    }
}
