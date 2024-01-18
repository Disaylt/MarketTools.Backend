using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Wb.Connections.Seller.OpenApi.Commands.RefreshToken
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<OpenApiRefreshTokenCommand>
    {

        private readonly IRepository<WbSellerOpenApiConnectionEntity> _repository = _authUnitOfWork.WbSellerOpenApiConnections;

        public async Task Handle(OpenApiRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            WbSellerOpenApiConnectionEntity entity = await _repository.FirstAsync(x => x.Id == request.Id);

            entity.Token = request.Token;
            entity.IsActive = true;

            _repository.Update(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
