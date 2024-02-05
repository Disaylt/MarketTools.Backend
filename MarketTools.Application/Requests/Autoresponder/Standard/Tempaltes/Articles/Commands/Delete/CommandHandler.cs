using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Requests;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.Delete
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GenericDeleteCommand<StandardAutoresponderTemplateArticleEntity>, Unit>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticleEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();

        public async Task<Unit> Handle(GenericDeleteCommand<StandardAutoresponderTemplateArticleEntity> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateArticleEntity entity = await _repository
                .FirstAsync(x => x.Id == request.Id, cancellationToken);
            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
