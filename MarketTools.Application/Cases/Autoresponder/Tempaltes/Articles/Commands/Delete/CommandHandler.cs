using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Commands.Delete
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<AutoresponderTemplateArticle>>
    {
        private readonly IAuthRepository<AutoresponderTemplateArticle> _repository = _authUnitOfWork.AutoresponderTemplateArticles;

        public async Task Handle(DefaultDeleteCommand<AutoresponderTemplateArticle> request, CancellationToken cancellationToken)
        {
            AutoresponderTemplateArticle entity = await _repository
                .FirstAsync(x=> x.Id == request.Id, cancellationToken);
            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
