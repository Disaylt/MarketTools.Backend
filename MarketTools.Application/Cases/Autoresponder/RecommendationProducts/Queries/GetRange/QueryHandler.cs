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
        IAuthReadHelper _authReadHelper,
        IMapper _mapper)
        : IRequestHandler<GetRangeQuery, PageResult<RecommendationProductVm>>
    {
        private readonly DbSet<AutoresponderRecommendationProduct> _dbSet = _authUnitOfWork.GetDbSet<AutoresponderRecommendationProduct>();

        public Task<PageResult<RecommendationProductVm>> Handle(GetRangeQuery request, CancellationToken cancellationToken)
        {
            
        }

        private async Task<IEnumerable<AutoresponderRecommendationProduct>> GetRangeAsync(GetRangeQuery request, CancellationToken cancellationToken)
        {
            IQueryable<AutoresponderRecommendationProduct> dbRequest = _dbSet.Where(x => x.UserId == _authReadHelper.UserId);

            if(request.Article != null)
            {
                dbRequest = dbRequest.Where(x=> x.FeedbackArticle.Contains(request.Article));
            }

            dbRequest = dbRequest.Skip(request.Skip)
                .Take(request.Take);

            return await dbRequest.ToListAsync(cancellationToken);
        }

        private async Task<int> CountTotalAsync(GetRangeQuery request, CancellationToken cancellationToken)
        {
            if()

            return await _authUnitOfWork.AutoresponderRecommendationProducts
                .CountAsync(cancellationToken);
        }
    }
}
