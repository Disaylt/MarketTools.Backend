using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Requests;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Utilities;
using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Queries
{
    public class RecommendationProductGetRangeQuery : GetRangeQuery<StandardAutoresponderRecommendationProductEntity>
    {
        public string? Article { get; set; }
        public MarketplaceName? MarketplaceName { get; set; }
    }

    public class GetRangeQueryHandler
       (IAuthUnitOfWork _authUnitOfWork)
       : IRequestHandler<RecommendationProductGetRangeQuery, IEnumerable<StandardAutoresponderRecommendationProductEntity>>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();

        public async Task<IEnumerable<StandardAutoresponderRecommendationProductEntity>> Handle(RecommendationProductGetRangeQuery request, CancellationToken cancellationToken)
        {
            return await new RecommendationProductsQueryBuilder(_repository)
                .SetMarketplace(request.MarketplaceName)
                .SetArticle(request.Article)
                .SetPagination(request.PageRequest)
                .Build()
                .ToListAsync(cancellationToken);
        }
    }
}
