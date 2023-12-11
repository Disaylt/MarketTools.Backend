using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Queries.GetRange
{
    public class QueryHandler
        (IAuthUnitOfWork _authUnitOfWork,
        IMapper _mapper)
        : IRequestHandler<GetRangeQuery, PageResult<RecommendationProductVm>>
    {
        public async Task<PageResult<RecommendationProductVm>> Handle(GetRangeQuery request, CancellationToken cancellationToken)
        {
            int total = await GetDbRequest(request)
                .CountAsync(cancellationToken);
            IEnumerable<AutoresponderRecommendationProduct> entities = await GetDbRequest(request)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync(cancellationToken);

            IEnumerable<RecommendationProductVm> recommendationProducts = _mapper.Map<IEnumerable<RecommendationProductVm>>(entities);

            return new PageResult<RecommendationProductVm>(total, recommendationProducts);
        }

        private IQueryable<AutoresponderRecommendationProduct> GetDbRequest(GetRangeQuery request)
        {
            IQueryable<AutoresponderRecommendationProduct> dbRequest = _authUnitOfWork.AutoresponderRecommendationProducts
                .GetAsQueryable()
                .Where(x=> x.MarketplaceName == request.MarketplaceName);

            if (request.Article != null)
            {
                dbRequest = dbRequest.Where(x => x.FeedbackArticle == request.Article);
            }

            return dbRequest;
        }
    }
}
