using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Identity;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Interfaces.Limits;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.OpenApi.Command
{
    public class SellerOpenApiAddCommand : IRequest<MarketplaceConnectionEntity>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Token { get; set; }
        public MarketplaceName MarketplaceName { get; set; }
    }

    public class AddCommandValidator : AbstractValidator<SellerOpenApiAddCommand>
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
        IConnectionActivatorService<MarketplaceConnectionOpenApiEntity> _connectionActivator)
        : IRequestHandler<SellerOpenApiAddCommand, MarketplaceConnectionEntity>
    {
        private readonly IRepository<MarketplaceConnectionOpenApiEntity> _connectionRepository = _unitOfWork.GetRepository<MarketplaceConnectionOpenApiEntity>();

        public async Task<MarketplaceConnectionEntity> Handle(SellerOpenApiAddCommand request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionOpenApiEntity newEntity = Create(request);

            await _connectionActivator.ActivateAsync(newEntity);
            await _connectionRepository.AddAsync(newEntity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return newEntity;
        }

        private MarketplaceConnectionOpenApiEntity Create(SellerOpenApiAddCommand request)
        {
            return new MarketplaceConnectionOpenApiEntity
            {
                Description = request.Description,
                Name = request.Name,
                Token = request.Token,
                UserId = _identityContext.Context.UserId,
                MarketplaceName = request.MarketplaceName
            };
        }
    }
}
