using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.AddTemplate
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<AddTemplateToRatingCommand, StandardAutoresponderTemplateEntity>
    {

        private readonly IRepository<StandardAutoresponderConnectionRatingEntity> _ratingRepository = _authUnitOfWork.GetRepository<StandardAutoresponderConnectionRatingEntity>();
        private readonly IRepository<StandardAutoresponderTemplateEntity> _templateRepository = _authUnitOfWork.GetRepository<StandardAutoresponderTemplateEntity>();

        public async Task<StandardAutoresponderTemplateEntity> Handle(AddTemplateToRatingCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateEntity templateEntity = await _templateRepository.FirstAsync(x => x.Id == request.TemplateId);
            StandardAutoresponderConnectionRatingEntity ratingEntity = await GetAsync(request.ConnectionId, request.Rating);

            ratingEntity.Templates.Add(templateEntity);
            _ratingRepository.Update(ratingEntity);
            await _authUnitOfWork.CommintAsync(cancellationToken);

            return templateEntity;
        }

        private async Task<StandardAutoresponderConnectionRatingEntity> GetAsync(int connectionId, int rating)
        {
            return await _ratingRepository
                .GetAsQueryable()
                .Include(x=> x.Templates)
                .FirstAsync(x=> x.ConnectionId == connectionId && x.Rating == rating);
        }
    }
}
