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

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Queries.GetList
{
    public class QueryHandler
        (IUnitOfWork _unitOfWork,
        IMapper _mapper)
        : IRequestHandler<GetArticlesQuery, IEnumerable<ArticleVm>>
    {
        private readonly IRepository<AutoresponderTemplateArticle> _repository = _unitOfWork.GetRepository<AutoresponderTemplateArticle>();
        public async Task<IEnumerable<ArticleVm>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AutoresponderTemplateArticle> entities = await _repository.GetRangeAsync(x => x.TemplateId == request.TemplateId, cancellationToken);

            return _mapper.Map<IEnumerable<ArticleVm>>(entities);
        }
    }
}
