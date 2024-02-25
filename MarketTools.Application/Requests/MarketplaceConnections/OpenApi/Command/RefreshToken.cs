using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.Connections;
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
        IUserNotificationsService _userNotificationsService)
        : IRequestHandler<OpenApiRefreshTokenCommand, MarketplaceConnectionEntity>
    {

        private readonly IRepository<MarketplaceConnectionEntity> _repository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();

        public async Task<MarketplaceConnectionEntity> Handle(OpenApiRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionEntity entity = await _repository.FirstAsync(x => x.Id == request.Id);
            RefreshToken(entity, request);

            entity.NumConnectionsAttempt = 0;

            _repository.Update(entity);

            await _userNotificationsService.AddAsync($"Измение токена для API '{entity.Name}'. Маркетплейс: {entity.MarketplaceName}");

            await _authUnitOfWork.CommitAsync(cancellationToken);

            return entity;
        }

        private void RefreshToken(MarketplaceConnectionEntity newEntity, OpenApiRefreshTokenCommand request)
        {
            ApiConnectionDto apiConnection = new ApiConnectionDto { Token = request.Token };
            new MarketplaceConnectionConverterFactory()
                .Create<ApiConnectionDto>(newEntity)
                .SetDetails(apiConnection);
        }
    }
}
