using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.Add
{
    public class CommandHandler(IUnitOfWork _unitOfWork)
        : IRequestHandler<AddRatingCommand>
    {

        private readonly IRepository<StandardAutoresponderConnectionRatingEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderConnectionRatingEntity>();

        public async Task Handle(AddRatingCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderConnectionRatingEntity entity = Create(request);

            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);
        }

        private StandardAutoresponderConnectionRatingEntity Create(AddRatingCommand request)
        {
            return new StandardAutoresponderConnectionRatingEntity
            {
                ConnectionId = request.ConnectionId,
                Rating = request.Rating
            };
        }
    }
}
