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

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Queries.GetList
{
    public class QueryHandler
        (IUnitOfWork _unitOfWork)
        : IRequestHandler<ArticleGetArticlesQuery, IEnumerable<StandardAutoresponderTemplateArticleEntity>>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticleEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();
        public async Task<IEnumerable<StandardAutoresponderTemplateArticleEntity>> Handle(ArticleGetArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(x => x.TemplateId == request.TemplateId, cancellationToken);
        }
    }
}
