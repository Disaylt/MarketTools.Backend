using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.Connections;
using MarketTools.Domain.Interfaces.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Command.SellerOpenApi
{
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

    public class RefreshTokenCommandHandler(IAuthUnitOfWork _authUnitOfWork,
        IConnectionValidatorService _connectionValidatorService,
        IUserNotificationsService _userNotificationsService,
        IContextService<MarketplaceConnectionEntity> _connectionContextService,
        IConnectionConverter<ApiConnectionDto> _connectionConverter)
        : IRequestHandler<OpenApiRefreshTokenCommand, MarketplaceConnectionEntity>
    {

        private readonly IRepository<MarketplaceConnectionEntity> _repository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();

        public async Task<MarketplaceConnectionEntity> Handle(OpenApiRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            RefreshToken(request);
            await CheckServicesAsync(request.Token);
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

        private async Task CheckServicesAsync(string token)
        {
            if(string.IsNullOrEmpty(token) == false)
            {
                await _connectionValidatorService.CheckServices(_connectionContextService.Context);
            }
        }

        private void RefreshToken(OpenApiRefreshTokenCommand request)
        {
            ApiConnectionDto apiConnection = new ApiConnectionDto { Token = request.Token };
            _connectionConverter.SetDetails(_connectionContextService.Context, apiConnection);
        }
    }
}
