using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Articles.Commands
{
    public class ArticleDeleteAllCommand : IRequest<Unit>
    {
        public int TemplateId { get; set; }
    }

    public class DeleteAllCommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<ArticleDeleteAllCommand, Unit>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticleEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();
        public async Task<Unit> Handle(ArticleDeleteAllCommand request, CancellationToken cancellationToken)
        {
            await _repository.ExecuteDeleteAsync(x => x.TemplateId == request.TemplateId);

            return Unit.Value;
        }
    }
}
