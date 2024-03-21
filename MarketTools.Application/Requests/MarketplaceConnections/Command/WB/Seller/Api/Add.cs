using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api;
using MarketTools.Application.Models.Identity;
using MarketTools.Application.Requests.MarketplaceConnections.Command.SellerOpenApi;
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

namespace MarketTools.Application.Requests.MarketplaceConnections.Command.WB.Seller.Api
{
    public class AddWbSellerApiCommand : AddBaseCommand, IRequest<MarketplaceConnectionEntity>
    {
        public required string Token { get; set; }
    }

    public class AddCommandValidator : AbstractValidator<AddWbSellerApiCommand>
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
        IConnectionServiceFactory<IConnectionActivator> _connectionServiceFactory,
        IConnectionConverterFactory<IWbSellerApiConnectionConverter> _wbSellerApiConnectionBuilderFactory)
        : IRequestHandler<AddWbSellerApiCommand, MarketplaceConnectionEntity>
    {
        private readonly IRepository<MarketplaceConnectionEntity> _connectionRepository = _unitOfWork.GetRepository<MarketplaceConnectionEntity>();
        private readonly IConnectionActivator _connectionActivator = _connectionServiceFactory.Create(MarketplaceConnectionType.OpenApi, MarketplaceName.WB);

        public async Task<MarketplaceConnectionEntity> Handle(AddWbSellerApiCommand request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionEntity newEntity = Create(request);
            ChangeValues(newEntity, request);
            await _connectionActivator.ActivateAsync(newEntity);

            await _connectionRepository.AddAsync(newEntity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return newEntity;
        }

        private void ChangeValues(MarketplaceConnectionEntity newEntity, AddWbSellerApiCommand request)
        {
            IWbSellerApiConnectionConverter wbSellerApiConnectionConverter = _wbSellerApiConnectionBuilderFactory.Create(newEntity);
            wbSellerApiConnectionConverter.Change(request.Token);
        }

        private MarketplaceConnectionEntity Create(AddWbSellerApiCommand request)
        {
            return new MarketplaceConnectionEntity
            {
                Description = request.Description,
                Name = request.Name,
                UserId = _identityContext.Context.UserId,
                MarketplaceName = MarketplaceName.WB,
                ConnectionType = MarketplaceConnectionType.OpenApi
            };
        }
    }
}
