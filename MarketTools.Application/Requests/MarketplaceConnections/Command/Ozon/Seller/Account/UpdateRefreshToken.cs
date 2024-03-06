using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account;
using MarketTools.Application.Interfaces.Notifications;
using MarketTools.Application.Requests.MarketplaceConnections.Utilities;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Requests;
using MediatR;

namespace MarketTools.Application.Requests.MarketplaceConnections.Command.Ozon.Seller.Account
{
    public class UpdateRefreshTokenSellerAccountCommand : IRequest<MarketplaceConnectionEntity>, IConnectionContextCall
    {
        public required string Token { get; set; }
        public int ConnectionId { get; set; }
    }

    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork,
        IConnectionValidatorService _connectionValidatorService,
        IUserNotificationsService _userNotificationsService,
        IContextService<MarketplaceConnectionEntity> _connectionContextService,
        IOzonSellerAccountConnectionConverter _ozonSellerAccountConnectionConverter)
        : IRequestHandler<UpdateRefreshTokenSellerAccountCommand, MarketplaceConnectionEntity>
    {
        private readonly IRepository<MarketplaceConnectionEntity> _repository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();
        private readonly ActivateUtility _activateUtility = new ActivateUtility(_connectionValidatorService);

        public async Task<MarketplaceConnectionEntity> Handle(UpdateRefreshTokenSellerAccountCommand request, CancellationToken cancellationToken)
        {
            _ozonSellerAccountConnectionConverter
                .SetRefreshToken(request.Token)
                .Convert(_connectionContextService.Context);

            await _activateUtility.TryActivateAsync(request.Token, _connectionContextService.Context);

            _repository.Update(_connectionContextService.Context);

            await _userNotificationsService.AddAsync($"Измение токена для API '{_connectionContextService.Context.Name}'. Маркетплейс: {_connectionContextService.Context.MarketplaceName}");

            await _authUnitOfWork.CommitAsync(cancellationToken);

            return _connectionContextService.Context;
        }
    }
}
