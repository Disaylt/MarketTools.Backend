using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.OpenApi.Command.RefreshToken
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork, IConnectionActivator<MarketplaceConnectionOpenApiEntity> _connectionActivator)
        : IRequestHandler<OpenApiRefreshTokenCommand, MarketplaceConnectionEntity>
    {

        private readonly IRepository<MarketplaceConnectionOpenApiEntity> _repository = _authUnitOfWork.GetRepository<MarketplaceConnectionOpenApiEntity>();

        public async Task<MarketplaceConnectionEntity> Handle(OpenApiRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionOpenApiEntity entity = await _repository.FirstAsync(x => x.Id == request.Id);
            entity.Token = request.Token;
            await _connectionActivator.ActivateAsync(entity);

            _repository.Update(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);

            return entity;
        }
    }
}
