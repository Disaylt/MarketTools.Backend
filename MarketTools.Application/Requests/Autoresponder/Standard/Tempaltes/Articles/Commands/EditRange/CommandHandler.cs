using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Articles.Commands.EditRange
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<ArticlesEditRangeCommand, IEnumerable<StandardAutoresponderTemplateArticleEntity>>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticleEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();

        public async Task<IEnumerable<StandardAutoresponderTemplateArticleEntity>> Handle(ArticlesEditRangeCommand request, CancellationToken cancellationToken)
        {
            request.Articles = request.Articles
                .Where(x => string.IsNullOrEmpty(x) == false);

            List<StandardAutoresponderTemplateArticleEntity> entitiesForUpdate = await _repository.GetAsQueryable()
                .Where(x=> x.TemplateId == request.TemplateId)
                .ToListAsync();

            await AddRange(request, entitiesForUpdate, cancellationToken);
            DeleteRange(request, entitiesForUpdate);

            await _authUnitOfWork.CommintAsync(cancellationToken);

            return await _repository.GetRangeAsync(x=> x.TemplateId == request.TemplateId);
        }

        private void DeleteRange(ArticlesEditRangeCommand request, List<StandardAutoresponderTemplateArticleEntity> currentEntities)
        {
            List<StandardAutoresponderTemplateArticleEntity> entitiesForRemove = currentEntities
                .Where(entity => request.Articles.Contains(entity.Value) == false)
                .ToList();

            _repository.RemoveRange(entitiesForRemove);
        }

        private async Task AddRange(ArticlesEditRangeCommand request, List<StandardAutoresponderTemplateArticleEntity> currentEntities, CancellationToken cancellationToken)
        {
            List<string> currentArticles = currentEntities.Select(x => x.Value).ToList();
            IEnumerable<StandardAutoresponderTemplateArticleEntity> entitiesForAdd = request.Articles
                .Except(currentArticles)
                .Select(article => new StandardAutoresponderTemplateArticleEntity
                {
                    Value = article,
                    TemplateId = request.TemplateId
                });

            await _repository.AddRangeAsync(entitiesForAdd);
        }
    }
}
