using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Utilities;
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
    public class RecommendationProductCountQuery : IRequest<int>
    {
        public string? Article { get; set; }
        public MarketplaceName? MarketplaceName { get; set; }
    }

    public class CountQueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<RecommendationProductCountQuery, int>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();

        public async Task<int> Handle(RecommendationProductCountQuery request, CancellationToken cancellationToken)
        {
            return await new RecommendationProductsQueryBuilder(_repository)
                .SetMarketplace(request.MarketplaceName)
                .SetArticle(request.Article)
                .Build()
                .CountAsync(cancellationToken);
        }
    }
}
