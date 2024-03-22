using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Command
{
    public class ConnectionUpdateDescriptionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateCommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<ConnectionUpdateDescriptionCommand, Unit>
    {
        private readonly IRepository<MarketplaceConnectionEntity> _repository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();

        public async Task<Unit> Handle(ConnectionUpdateDescriptionCommand request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionEntity entity = await _repository.FirstAsync(x => x.Id == request.Id, cancellationToken);
            entity.Description = request.Description;

            _repository.Update(entity);

            await _authUnitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
