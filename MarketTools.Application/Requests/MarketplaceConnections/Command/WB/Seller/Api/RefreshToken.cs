﻿using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Requests.MarketplaceConnections.Command.SellerOpenApi;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Command.WB.Seller.Api
{
    public class RefreshTokenCommand : IRequest<MarketplaceConnectionEntity>, IConnectionContextCall
    {
        public required string Token { get; set; }
        public int ConnectionId { get; set; }
    }

    public class RefreshTokenCommandHandler(IAuthUnitOfWork _authUnitOfWork,
        IConnectionValidatorService _connectionValidatorService,
        IUserNotificationsService _userNotificationsService,
        IContextService<MarketplaceConnectionEntity> _connectionContextService,
        IWbSellerApiConnectionConverter _wbSellerApiConnectionBuilder)
        : IRequestHandler<RefreshTokenCommand, MarketplaceConnectionEntity>
    {
        private readonly IRepository<MarketplaceConnectionEntity> _repository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();
        public async Task<MarketplaceConnectionEntity> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            _wbSellerApiConnectionBuilder
                .SetToken(request.Token)
                .Convert(_connectionContextService.Context);

            await CheckServicesAsync(request.Token);
            ChangeProperties(request);

            _repository.Update(_connectionContextService.Context);

            await _userNotificationsService.AddAsync($"Измение токена для API '{_connectionContextService.Context.Name}'. Маркетплейс: {_connectionContextService.Context.MarketplaceName}");

            await _authUnitOfWork.CommitAsync(cancellationToken);

            return _connectionContextService.Context;
        }

        private void ChangeProperties(RefreshTokenCommand request)
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
            if (string.IsNullOrEmpty(token) == false)
            {
                await _connectionValidatorService.CheckServices(_connectionContextService.Context);
            }
        }
    }
}
