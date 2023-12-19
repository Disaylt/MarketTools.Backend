using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Commands.AddRange
{
    public class CommandHandler
        (IMapper _mapper,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<AddRangeCommand, IEnumerable<ArticleVm>>
    {
        private readonly IRepository<AutoresponderStandardTemplateArticle> _repository = _unitOfWork.GetRepository<AutoresponderStandardTemplateArticle>();
        public async Task<IEnumerable<ArticleVm>> Handle(AddRangeCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<AutoresponderStandardTemplateArticle> newEntities = await BuildOnlyNewArticlesAsync(request, cancellationToken);
            await _repository.AddRangeAsync(newEntities, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ArticleVm>>(newEntities);
        }

        private async Task<IEnumerable<AutoresponderStandardTemplateArticle>> BuildOnlyNewArticlesAsync(AddRangeCommand request, CancellationToken ct)
        {
            IEnumerable<AutoresponderStandardTemplateArticle> currentEntities = await _repository.GetRangeAsync(x=> x.TemplateId == request.TemplateId, ct);
            
            return request.Articles
                .Where(article => currentEntities.Any(entity => entity.Article == article) == false)
                .Select(x => new AutoresponderStandardTemplateArticle
                {
                    Article = x,
                    TemplateId = request.TemplateId,
                });
        }
    }
}
