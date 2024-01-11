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
        private readonly IRepository<StandardAutoresponderTemplateArticleEntity> _repository = _authUnitOfWork.StandardAutoresponderTemplateArticles;

        public async Task<IEnumerable<StandardAutoresponderTemplateArticleEntity>> Handle(ArticlesEditRangeCommand request, CancellationToken cancellationToken)
        {

            List<StandardAutoresponderTemplateArticleEntity> currentEntities = await _repository.GetAsQueryable()
                .Where(x=> x.TemplateId == request.TemplateId)
                .ToListAsync();

            await AddRange(request, currentEntities, cancellationToken);
            DeleteRange(request, currentEntities);

            await _authUnitOfWork.CommintAsync(cancellationToken);

            return currentEntities;
        }

        private void DeleteRange(ArticlesEditRangeCommand request, List<StandardAutoresponderTemplateArticleEntity> currentEntities)
        {
            List<StandardAutoresponderTemplateArticleEntity> entitiesForRemove = currentEntities
                .Where(entity => request.Articles.Contains(entity.Article) == false)
                .ToList();

            _repository.RemoveRange(entitiesForRemove);

            foreach(StandardAutoresponderTemplateArticleEntity entity in entitiesForRemove)
            {
                currentEntities.Remove(entity);
            }
        }

        private async Task AddRange(ArticlesEditRangeCommand request, List<StandardAutoresponderTemplateArticleEntity> currentEntities, CancellationToken cancellationToken)
        {
            List<string> currentArticles = currentEntities.Select(x => x.Article).ToList();
            IEnumerable<StandardAutoresponderTemplateArticleEntity> entitiesForAdd = request.Articles
                .Except(currentArticles)
                .Select(article => new StandardAutoresponderTemplateArticleEntity
                {
                    Article = article,
                    TemplateId = request.TemplateId
                });

            currentEntities.AddRange(entitiesForAdd);
            await _repository.AddRangeAsync(entitiesForAdd);
        }
    }
}
