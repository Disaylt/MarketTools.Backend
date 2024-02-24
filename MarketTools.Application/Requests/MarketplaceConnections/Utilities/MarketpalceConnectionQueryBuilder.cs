using MarketTools.Application.Common.Builders.Requests;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Utilities
{
    internal class MarketpalceConnectionQueryBuilder : BaseQueryBuilder<MarketplaceConnectionEntity>
    {
        public MarketpalceConnectionQueryBuilder(IQueryable<MarketplaceConnectionEntity> query) : base(query)
        {

        }

        public virtual MarketpalceConnectionQueryBuilder SetMarketplace(MarketplaceName? marketplaceName)
        {
            if (marketplaceName != null)
            {
                Query = Query.Where(x => x.MarketplaceName == marketplaceName);
            }

            return this;
        }

        public virtual MarketpalceConnectionQueryBuilder SetByService(EnumProjectServices? projectService, 
            MarketplaceName? marketplaceName, 
            IProjectServiceFactory<IConnectionDefinitionService> connectionDefinitionService)
        {
            if(projectService.HasValue && marketplaceName.HasValue)
            {
                MarketplaceConnectionType type = connectionDefinitionService
                    .Create(projectService.Value)
                    .Create(marketplaceName.Value)
                    .Get();

                Query = Query.Where(x => x.ConnectionType == type);
            }

            return this;
        }

        public virtual MarketpalceConnectionQueryBuilder SetByType(MarketplaceConnectionType? type)
        {
            if (type.HasValue)
            {
                Query = Query.Where(x => x.ConnectionType == type.Value);
            }

            return this;
        }
    }
}
