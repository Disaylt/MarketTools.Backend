using FluentValidation;
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
    public class AddRatingCommand : IRequest<Unit>
    {
        public int ConnectionId { get; set; }
        public int Rating { get; set; }
    }

    public class AddCommandValidator : AbstractValidator<AddRatingCommand>
    {
        public AddCommandValidator(IAuthUnitOfWork authUnitOfWork)
        {
            RuleFor(x => x.ConnectionId)
                .MustAsync(async (connectionId, ct) =>
                {
                    return await authUnitOfWork.GetRepository<MarketplaceConnectionEntity>()
                        .AnyAsync(x => x.Id == connectionId, ct);
                })
                .WithErrorCode("404")
                .WithMessage("Подключение не найдено.");
        }
    }

    public class AddCommandHandler(IUnitOfWork _unitOfWork)
        : IRequestHandler<AddRatingCommand, Unit>
    {

        private readonly IRepository<StandardAutoresponderConnectionRatingEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderConnectionRatingEntity>();

        public async Task<Unit> Handle(AddRatingCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderConnectionRatingEntity entity = Create(request);

            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
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
