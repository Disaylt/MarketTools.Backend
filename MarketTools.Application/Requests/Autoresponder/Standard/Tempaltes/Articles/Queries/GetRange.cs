using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Articles.Queries
{
    public class GetRangeArticlesQuery : TemplateBasicCommand, IRequest<IEnumerable<StandardAutoresponderTemplateArticleEntity>>
    {

    }

    public class QueryHandler
        (IAuthUnitOfWork _unitOfWork)
        : IRequestHandler<GetRangeArticlesQuery, IEnumerable<StandardAutoresponderTemplateArticleEntity>>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticleEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();
        public async Task<IEnumerable<StandardAutoresponderTemplateArticleEntity>> Handle(GetRangeArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(x => x.TemplateId == request.TemplateId, cancellationToken);
        }
    }
}
