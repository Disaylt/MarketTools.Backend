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
        private readonly IAuthRepository<StandardAutoresponderRecommendationProduct> _repository = _authUnitOfWork.AutoresponderRecommendationProducts;
        public async Task<PageResult<RecommendationProductVm>> Handle(GetRangeQuery request, CancellationToken cancellationToken)
        {
            IQueryable<StandardAutoresponderRecommendationProduct> query = GetDbQueery(request);
            IEnumerable<StandardAutoresponderRecommendationProduct> entities = await GetEntitiesAsync(request, query, cancellationToken);
            int total = await query.CountAsync(cancellationToken);

            IEnumerable<RecommendationProductVm> recommendationProducts = _mapper.Map<IEnumerable<RecommendationProductVm>>(entities);

            return new PageResult<RecommendationProductVm>(total, recommendationProducts);
        }

        private async Task<IEnumerable<StandardAutoresponderRecommendationProduct>> GetEntitiesAsync(GetRangeQuery request, IQueryable<StandardAutoresponderRecommendationProduct> query, CancellationToken cancellationToken)
        {
            return await query
                .OrderBy(x => x.Id)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync(cancellationToken);
        }

        private IQueryable<StandardAutoresponderRecommendationProduct> GetDbQueery(GetRangeQuery request)
        {
            IQueryable<StandardAutoresponderRecommendationProduct> query = _repository
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
