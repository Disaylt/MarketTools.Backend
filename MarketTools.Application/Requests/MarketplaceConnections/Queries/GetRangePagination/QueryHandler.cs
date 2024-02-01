using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Queries.GetRangePagination
{
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetRangePaginationMarketplaceConnectionsQuery, IEnumerable<MarketplaceConnectionEntity>>
    {
        public async Task<IEnumerable<MarketplaceConnectionEntity>> Handle(GetRangePaginationMarketplaceConnectionsQuery request, CancellationToken cancellationToken)
        {
            string discriminator = new MarketplaceConnectionsDiscriminatorFactory().Get(request.ConnectionType);

            IQueryable<MarketplaceConnectionEntity> dbQuery = _authUnitOfWork
                .SellerConnections
                .GetAsQueryable();

            return await new MarketpalceConnectionQueryBuilder(dbQuery)
                    .SetPagination(request.PageRequest)
                    .Build()
                    .Where(x => x.Discriminator == discriminator)
                    .Include(x=> x.AutoresponderConnection)
                    .ToListAsync();
        }
    }
}
