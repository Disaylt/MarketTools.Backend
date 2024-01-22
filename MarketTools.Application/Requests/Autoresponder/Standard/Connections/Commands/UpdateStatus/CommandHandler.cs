using MarketTools.Application.Interfaces.Database;
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
        : IRequestHandler<UpdateConenctionStatusCommand>
    {
        private readonly IRepository<StandardAutoresponderConnectionEntity> _repository = _authUnitOfWork.StandardAutoresponderConnections;

        public async Task Handle(UpdateConenctionStatusCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderConnectionEntity entity = await _repository.FirstAsync(x => x.SellerConnectionId == request.Id, cancellationToken);

            entity.IsActive = request.IsActive;

            _repository.Update(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
