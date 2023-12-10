using MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Queries.GetRange
{
    public class QueryHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetRangeQuery, PageResult<RecommendationProductVm>>
    {
        public Task<PageResult<RecommendationProductVm>> Handle(GetRangeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async Task<int> CountTotal()
        {
           
        }
    }
}
