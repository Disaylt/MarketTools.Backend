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

            IEnumerable<StandardAutoresponderTemplateArticleEntity> currentEntities = await _repository
                .GetRangeAsync(x => x.TemplateId == request.TemplateId, cancellationToken);

            await AddRange(request, currentEntities, cancellationToken);
            DeleteRange(request, currentEntities);

            await _authUnitOfWork.CommintAsync(cancellationToken);

            return currentEntities;
        }

        private void DeleteRange(ArticlesEditRangeCommand request, IEnumerable<StandardAutoresponderTemplateArticleEntity> currentEntities)
        {
            List<StandardAutoresponderTemplateArticleEntity> entityForRemove = new List<StandardAutoresponderTemplateArticleEntity>();

            foreach(StandardAutoresponderTemplateArticleEntity entity in currentEntities)
            {
                if (request.Articles.Contains(entity.Article))
                {
                    continue;
                }

                entityForRemove.Add(entity);
            }

            _repository.RemoveRange(entityForRemove);
        }

        private async Task AddRange(ArticlesEditRangeCommand request, IEnumerable<StandardAutoresponderTemplateArticleEntity> currentEntities, CancellationToken cancellationToken)
        {
            List<StandardAutoresponderTemplateArticleEntity> entityForAdd = new List<StandardAutoresponderTemplateArticleEntity>();

            foreach (string article in request.Articles)
            {
                if(currentEntities.Any(x=> x.Article == article))
                {
                    continue;
                }
                StandardAutoresponderTemplateArticleEntity newEntity = new StandardAutoresponderTemplateArticleEntity
                {
                    Article = article,
                    TemplateId = request.TemplateId
                };
                entityForAdd.Add(newEntity);
            }

            await _repository.AddRangeAsync(entityForAdd);
        }
    }
}
