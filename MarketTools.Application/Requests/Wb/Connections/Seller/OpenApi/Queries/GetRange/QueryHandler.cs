using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Requests;
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
        : IRequestHandler<IGetRangePaginationQuery<WbSellerOpenApiConnectionEntity>, IEnumerable<WbSellerOpenApiConnectionEntity>>
    {
        public async Task<IEnumerable<WbSellerOpenApiConnectionEntity>> Handle(IGetRangePaginationQuery<WbSellerOpenApiConnectionEntity> request, CancellationToken cancellationToken)
        {
            return await _authUnitOfWork.WbSellerOpenApiConnections
                .GetAsQueryable()
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();
        }
    }
}
