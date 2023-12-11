﻿using AutoMapper;
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
using System.Threading;
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
            IQueryable<AutoresponderRecommendationProduct> query = GetDbQueery(request);
            IEnumerable<AutoresponderRecommendationProduct> entities = await GetEntitiesAsync(request, query, cancellationToken);
            int total = await query.CountAsync(cancellationToken);

            IEnumerable<RecommendationProductVm> recommendationProducts = _mapper.Map<IEnumerable<RecommendationProductVm>>(entities);

            return new PageResult<RecommendationProductVm>(total, recommendationProducts);
        }

        private async Task<IEnumerable<AutoresponderRecommendationProduct>> GetEntitiesAsync(GetRangeQuery request, IQueryable<AutoresponderRecommendationProduct> query, CancellationToken cancellationToken)
        {
            return await query
                .OrderBy(x => x.Id)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync(cancellationToken);
        }

        private IQueryable<AutoresponderRecommendationProduct> GetDbQueery(GetRangeQuery request)
        {
            IQueryable<AutoresponderRecommendationProduct> query = _authUnitOfWork.AutoresponderRecommendationProducts
                .GetAsQueryable()
                .Where(x=> x.MarketplaceName == request.MarketplaceName);

            if (request.Article != null)
            {
                query = query.Where(x => x.FeedbackArticle == request.Article);
            }

            return query;
        }
    }
}
