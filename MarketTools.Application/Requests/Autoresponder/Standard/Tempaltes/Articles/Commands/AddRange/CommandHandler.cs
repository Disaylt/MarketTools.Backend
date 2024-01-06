using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.AddRange
{
    public class CommandHandler
        (IUnitOfWork _unitOfWork)
        : IRequestHandler<AddRangeCommand, IEnumerable<StandardAutoresponderTemplateArticleEntity>>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticleEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();
        public async Task<IEnumerable<StandardAutoresponderTemplateArticleEntity>> Handle(AddRangeCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderTemplateArticleEntity> newEntities = await BuildOnlyNewArticlesAsync(request, cancellationToken);
            await _repository.AddRangeAsync(newEntities, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return newEntities;
        }

        private async Task<IEnumerable<StandardAutoresponderTemplateArticleEntity>> BuildOnlyNewArticlesAsync(AddRangeCommand request, CancellationToken ct)
        {
            IEnumerable<StandardAutoresponderTemplateArticleEntity> currentEntities = await _repository.GetRangeAsync(x => x.TemplateId == request.TemplateId, ct);

            return request.Articles
                .Where(article => currentEntities.Any(entity => entity.Article == article) == false)
                .Select(x => new StandardAutoresponderTemplateArticleEntity
                {
                    Article = x,
                    TemplateId = request.TemplateId,
                });
        }
    }
}
