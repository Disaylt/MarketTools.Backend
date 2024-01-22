using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.DeleteTemplate
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<RatingDeleteTemplateCommand>
    {

        private readonly IRepository<StandardAutoresponderConnectionRatingEntity> _repository = _authUnitOfWork.StandardAutoresponderConnectionRatings;

        public async Task Handle(RatingDeleteTemplateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderConnectionRatingEntity entity = await _repository
               .GetAsQueryable()
               .Include(x => x.Templates)
               .FirstAsync(x => x.ConnectionId == request.ConnectionId && x.Rating == request.Rating, cancellationToken);

            StandardAutoresponderTemplateEntity template = entity.Templates.FirstOrDefault(x => x.Id == request.TemplateId)
                ?? throw new AppNotFoundException("Шаблон не найден.");

            entity.Templates.Remove(template);

            _repository.Update(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
