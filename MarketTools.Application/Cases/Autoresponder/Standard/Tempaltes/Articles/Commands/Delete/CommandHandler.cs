using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Commands;
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
        : IRequestHandler<DefaultDeleteCommand<StandardAutoresponderTemplateArticle>>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticle> _repository = _authUnitOfWork.StandardAutoresponderTemplateArticles;

        public async Task Handle(DefaultDeleteCommand<StandardAutoresponderTemplateArticle> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateArticle entity = await _repository
                .FirstAsync(x => x.Id == request.Id, cancellationToken);
            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
