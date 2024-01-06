using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Queries.Count
{
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<CountQuery, int>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProduct> _repository = _authUnitOfWork.StandardAutoresponderRecommendationProducts;

        public async Task<int> Handle(CountQuery request, CancellationToken cancellationToken)
        {
            return await new RecommendationProductsQueryBuilder(_repository)
                .SetMarketplace(request.MarketplaceName)
                .SetArticle(request.Article)
                .Build()
                .CountAsync(cancellationToken);
        }
    }
}
