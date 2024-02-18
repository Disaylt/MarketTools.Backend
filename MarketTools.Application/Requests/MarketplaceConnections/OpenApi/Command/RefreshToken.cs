using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.OpenApi.Command
{
    public class OpenApiRefreshTokenCommand : IRequest<MarketplaceConnectionEntity>
    {
        public int Id { get; set; }
        public required string Token { get; set; }
    }

    public class RefreshTokenCommandHandler(IAuthUnitOfWork _authUnitOfWork,
        IConnectionActivator<MarketplaceConnectionOpenApiEntity> _connectionActivator,
        IUserNotificationsService _userNotificationsService)
        : IRequestHandler<OpenApiRefreshTokenCommand, MarketplaceConnectionEntity>
    {

        private readonly IRepository<MarketplaceConnectionOpenApiEntity> _repository = _authUnitOfWork.GetRepository<MarketplaceConnectionOpenApiEntity>();

        public async Task<MarketplaceConnectionEntity> Handle(OpenApiRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionOpenApiEntity entity = await _repository.FirstAsync(x => x.Id == request.Id);

            entity.Token = request.Token;
            entity.NumConnectionsAttempt = 0;
            await _connectionActivator.ActivateAsync(entity);

            _repository.Update(entity);

            await _userNotificationsService.AddAsync($"Измение токена для API '{entity.Name}'. Маркетплейс: {entity.MarketplaceName}");

            await _authUnitOfWork.CommitAsync(cancellationToken);

            return entity;
        }
    }
}
