using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands
{
    public class RatingDeleteCommand : IRequest<Unit>
    {
        public int Rating { get; set; }
        public int ConnectionId { get; set; }
    }

    public class DeleteCommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<RatingDeleteCommand, Unit>
    {
        private readonly IRepository<StandardAutoresponderConnectionRatingEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderConnectionRatingEntity>();

        public async Task<Unit> Handle(RatingDeleteCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderConnectionRatingEntity entity = await _repository
                .FirstAsync(x => x.ConnectionId == request.ConnectionId && x.Rating == request.Rating, cancellationToken);

            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
