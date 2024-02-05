using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Connections.Commands.UpdateStatus
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<UpdateConnenctionStatusCommand, Unit>
    {
        private readonly IRepository<StandardAutoresponderConnectionEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderConnectionEntity>();

        public async Task<Unit> Handle(UpdateConnenctionStatusCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderConnectionEntity entity = await _repository.FirstAsync(x => x.SellerConnectionId == request.Id, cancellationToken);

            entity.IsActive = request.IsActive;

            _repository.Update(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);

            return Unit.Value;
        }


    }
}
