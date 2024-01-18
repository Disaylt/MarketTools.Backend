using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Command.Delete
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<MarketplaceConnectionEntity>>
    {

        private readonly IRepository<MarketplaceConnectionEntity> _repository = _authUnitOfWork.SellerConnections;

        public async Task Handle(DefaultDeleteCommand<MarketplaceConnectionEntity> request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionEntity entity = await _repository.FirstAsync(x => x.Id == request.Id, cancellationToken);

            _repository.Remove(entity);

            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
