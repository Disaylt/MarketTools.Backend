using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
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
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork, IMarketplaceConnectionFactory _marketplaceConnectionFactory)
        : IRequestHandler<GetRangePaginationMarketplaceConnectionsQuery, IEnumerable<MarketplaceConnectionEntity>>
    {
        public async Task<IEnumerable<MarketplaceConnectionEntity>> Handle(GetRangePaginationMarketplaceConnectionsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<MarketplaceConnectionEntity> dbQuery = _authUnitOfWork
                .GetRepository<MarketplaceConnectionEntity>()
                .GetAsQueryable();

            return await new MarketpalceConnectionQueryBuilder(dbQuery)
                    .SetMarketplace(request.MarketplaceName)
                    .SetPagination(request.PageRequest)
                    .SetByService(_marketplaceConnectionFactory, request.ProjectService)
                    .SetByType(request.ConnectionType)
                    .Build()
                    .Include(x=> x.AutoresponderConnection)
                    .ToListAsync();
        }
    }
}
