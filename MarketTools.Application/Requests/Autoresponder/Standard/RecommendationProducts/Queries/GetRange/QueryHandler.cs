using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Queries;
using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Queries.GetRange
{
    public class QueryHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetRangeQuery, IEnumerable<StandardAutoresponderRecommendationProduct>>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProduct> _repository = _authUnitOfWork.StandardAutoresponderRecommendationProducts;

        public async Task<IEnumerable<StandardAutoresponderRecommendationProduct>> IRequestHandler<GetRangeQuery, IEnumerable<StandardAutoresponderRecommendationProduct>>.Handle(GetRangeQuery request, CancellationToken cancellationToken)
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
