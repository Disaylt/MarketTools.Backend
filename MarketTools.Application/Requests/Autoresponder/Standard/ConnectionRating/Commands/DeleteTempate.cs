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

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands
{
    public class DeleteTemplateCommand : IRequest<Unit>
    {
        public int ConnectionId { get; set; }
        public int Rating { get; set; }
        public int TemplateId { get; set; }
    }

    public class DeleteTemplateCommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DeleteTemplateCommand, Unit>
    {

        private readonly IRepository<StandardAutoresponderConnectionRatingEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderConnectionRatingEntity>();

        public async Task<Unit> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderConnectionRatingEntity entity = await _repository
               .GetAsQueryable()
               .Include(x => x.Templates)
               .FirstAsync(x => x.ConnectionId == request.ConnectionId && x.Rating == request.Rating, cancellationToken);

            StandardAutoresponderTemplateEntity template = entity.Templates.FirstOrDefault(x => x.Id == request.TemplateId)
                ?? throw new AppNotFoundException("Шаблон не найден.");

            entity.Templates.Remove(template);

            _repository.Update(entity);
            await _authUnitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
