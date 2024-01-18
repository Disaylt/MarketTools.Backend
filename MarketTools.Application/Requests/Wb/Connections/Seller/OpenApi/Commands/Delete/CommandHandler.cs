using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Wb.Connections.Seller.OpenApi.Commands.Delete
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<WbSellerOpenApiConnectionEntity>>
    {

        private readonly IRepository<WbSellerOpenApiConnectionEntity> _repository = _authUnitOfWork.WbSellerOpenApiConnections;

        public async Task Handle(DefaultDeleteCommand<WbSellerOpenApiConnectionEntity> request, CancellationToken cancellationToken)
        {
            WbSellerOpenApiConnectionEntity entity = await _repository.FirstAsync(x=> x.Id == request.Id, cancellationToken);

            _repository.Remove(entity);

            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
