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
        : IRequestHandler<AddRangeCommand, IEnumerable<StandardAutoresponderTemplateArticle>>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticle> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplateArticle>();
        public async Task<IEnumerable<StandardAutoresponderTemplateArticle>> Handle(AddRangeCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderTemplateArticle> newEntities = await BuildOnlyNewArticlesAsync(request, cancellationToken);
            await _repository.AddRangeAsync(newEntities, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return newEntities;
        }

        private async Task<IEnumerable<StandardAutoresponderTemplateArticle>> BuildOnlyNewArticlesAsync(AddRangeCommand request, CancellationToken ct)
        {
            IEnumerable<StandardAutoresponderTemplateArticle> currentEntities = await _repository.GetRangeAsync(x => x.TemplateId == request.TemplateId, ct);

            return request.Articles
                .Where(article => currentEntities.Any(entity => entity.Article == article) == false)
                .Select(x => new StandardAutoresponderTemplateArticle
                {
                    Article = x,
                    TemplateId = request.TemplateId,
                });
        }
    }
}
