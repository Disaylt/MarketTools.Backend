using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Identity;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Interfaces.Limits;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Command.SellerOpenApi
{
    [Obsolete]
    public class SellerOpenApiAddCommand : IRequest<MarketplaceConnectionEntity>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Token { get; set; }
        public MarketplaceName MarketplaceName { get; set; }
    }

    [Obsolete]
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

    [Obsolete]
    public class AddCommandHandler(IUnitOfWork _unitOfWork,
        IContextService<IdentityContext> _identityContext)
        : IRequestHandler<SellerOpenApiAddCommand, MarketplaceConnectionEntity>
    {
        private readonly IRepository<MarketplaceConnectionEntity> _connectionRepository = _unitOfWork.GetRepository<MarketplaceConnectionEntity>();

        public async Task<MarketplaceConnectionEntity> Handle(SellerOpenApiAddCommand request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionEntity newEntity = Create(request);

            await _connectionRepository.AddAsync(newEntity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return newEntity;
        }

        private MarketplaceConnectionEntity Create(SellerOpenApiAddCommand request)
        {
            return new MarketplaceConnectionEntity
            {
                Description = request.Description,
                Name = request.Name,
                UserId = _identityContext.Context.UserId,
                MarketplaceName = request.MarketplaceName,
                ConnectionType = MarketplaceConnectionType.OpenApi
            };
        }
    }
}
