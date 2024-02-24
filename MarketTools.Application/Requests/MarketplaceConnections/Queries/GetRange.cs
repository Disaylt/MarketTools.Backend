using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Requests;
using MarketTools.Application.Requests.MarketplaceConnections.Utilities;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Queries
{
    public class GetRangeMarketplaceConnectionsQuery : GetRangeQuery<MarketplaceConnectionEntity>
    {
        public MarketplaceConnectionType? ConnectionType { get; set; }
        public MarketplaceName? MarketplaceName { get; set; }
        public EnumProjectServices? ProjectService { get; set; }
    }

    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork, IProjectServiceFactory<IConnectionDefinitionService> _connectionDefinitionService)
        : IRequestHandler<GetRangeMarketplaceConnectionsQuery, IEnumerable<MarketplaceConnectionEntity>>
    {
        public async Task<IEnumerable<MarketplaceConnectionEntity>> Handle(GetRangeMarketplaceConnectionsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<MarketplaceConnectionEntity> dbQuery = _authUnitOfWork
                .GetRepository<MarketplaceConnectionEntity>()
                .GetAsQueryable();

            return await new MarketpalceConnectionQueryBuilder(dbQuery)
                    .SetMarketplace(request.MarketplaceName)
                    .SetByService(request.ProjectService, request.MarketplaceName, _connectionDefinitionService)
                    .SetByType(request.ConnectionType)
                    .SetPagination(request.PageRequest)
                    .Build()
                    .Include(x => x.AutoresponderConnection)
                    .ToListAsync();
        }
    }
}
