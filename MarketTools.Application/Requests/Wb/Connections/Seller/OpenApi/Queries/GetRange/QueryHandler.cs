using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Requests;
using MarketTools.Application.Models.Requests;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Wb.Connections.Seller.OpenApi.Queries.GetRange
{
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetRangePaginationQuery<WbSellerOpenApiConnectionEntity>, IEnumerable<WbSellerOpenApiConnectionEntity>>
    {
        public async Task<IEnumerable<WbSellerOpenApiConnectionEntity>> Handle(GetRangePaginationQuery<WbSellerOpenApiConnectionEntity> request, CancellationToken cancellationToken)
        {
            return await _authUnitOfWork.WbSellerOpenApiConnections
                .GetAsQueryable()
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();
        }
    }
}
