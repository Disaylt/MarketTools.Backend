using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account;
using MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api;
using MarketTools.Application.Models.Identity;
using MarketTools.Application.Requests.MarketplaceConnections.Models;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Interfaces.Limits;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Command.Ozon.Seller.Account
{
    public class AddOzonSellerAccountCommand : AddBaseCommand, IRequest<MarketplaceConnectionEntity>
    {
        public required string RefreshToken { get; set; }
        public required string SellerId { get; set; }
    }

    public class AddCommandValidator : AbstractValidator<AddOzonSellerAccountCommand>
    {
        public AddCommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IMarketplaceConnectionLimits> limitsService)
        {
            IRepository<MarketplaceConnectionEntity> repository = authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();

            RuleFor(x => x)
                .MustAsync(async (x, ct) =>
                {
                    int numConnections = await repository.CountAsync();
                    IMarketplaceConnectionLimits limits = await limitsService.GetAsync();

                    return numConnections < limits.MaxConnections;
                });
        }
    }

    public class AddCommandHandler(IUnitOfWork _unitOfWork,
        IContextService<IdentityContext> _identityContext,
        IOzonSellerAccountConnectionConverter _ozonSellerAccountConnectionConverter)
        : IRequestHandler<AddOzonSellerAccountCommand, MarketplaceConnectionEntity>
    {
        private readonly IRepository<MarketplaceConnectionEntity> _connectionRepository = _unitOfWork.GetRepository<MarketplaceConnectionEntity>();

        public async Task<MarketplaceConnectionEntity> Handle(AddOzonSellerAccountCommand request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionEntity newEntity = Create(request);
            _ozonSellerAccountConnectionConverter
                .SetSellerId(request.SellerId)
                .SetRefreshToken(request.RefreshToken)
                .Convert(newEntity);

            await _connectionRepository.AddAsync(newEntity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return newEntity;
        }

        private MarketplaceConnectionEntity Create(AddOzonSellerAccountCommand request)
        {
            return new MarketplaceConnectionEntity
            {
                Description = request.Description,
                Name = request.Name,
                UserId = _identityContext.Context.UserId,
                MarketplaceName = MarketplaceName.OZON,
                ConnectionType = MarketplaceConnectionType.Account
            };
        }
    }
}
