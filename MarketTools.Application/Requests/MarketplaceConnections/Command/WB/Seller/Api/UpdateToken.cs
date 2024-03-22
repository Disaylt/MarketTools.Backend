﻿using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Requests.MarketplaceConnections.Command.SellerOpenApi;
using MarketTools.Application.Requests.MarketplaceConnections.Utilities;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Interfaces.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Command.WB.Seller.Api
{
    public class UpdateTokenSellerApiCommand : IRequest<MarketplaceConnectionEntity>, IConnectionContextCall
    {
        public required string Token { get; set; }
        public int ConnectionId { get; set; }
    }

    public class RefreshTokenCommandHandler(IAuthUnitOfWork _authUnitOfWork,
        IUserNotificationsService _userNotificationsService,
        IContextService<MarketplaceConnectionEntity> _connectionContextService,
        IConnectionServiceFactory<IConnectionActivator> _connectionServiceFactory,
        IConnectionConverterFactory<IWbSellerApiConnectionConverter> _wbSellerApiConnectionConverterFactory)
        : IRequestHandler<UpdateTokenSellerApiCommand, MarketplaceConnectionEntity>
    {
        private readonly IRepository<MarketplaceConnectionEntity> _repository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();
        private readonly IWbSellerApiConnectionConverter _wbSellerApiConnectionConverter = _wbSellerApiConnectionConverterFactory.CreateFromContext();
        private readonly IConnectionActivator _connectionActivator = _connectionServiceFactory.Create(MarketplaceConnectionType.OpenApi, MarketplaceName.WB);

        public async Task<MarketplaceConnectionEntity> Handle(UpdateTokenSellerApiCommand request, CancellationToken cancellationToken)
        {
            _wbSellerApiConnectionConverter.Change(request.Token);
            await _connectionActivator.ActivateAsync(_connectionContextService.Context);

            _repository.Update(_connectionContextService.Context);

            await _userNotificationsService.AddAsync($"Измение токена для API '{_connectionContextService.Context.Name}'. Маркетплейс: {_connectionContextService.Context.MarketplaceName}");

            await _authUnitOfWork.CommitAsync(cancellationToken);

            return _connectionContextService.Context;
        }

    }
}
