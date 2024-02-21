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
        private MarketplaceName? _marketplaceName;

        public MarketpalceConnectionQueryBuilder(IQueryable<MarketplaceConnectionEntity> query) : base(query)
        {

        }

        public virtual MarketpalceConnectionQueryBuilder SetMarketplace(MarketplaceName? marketplaceName)
        {
            if (marketplaceName != null)
            {
                _marketplaceName = marketplaceName;
                Query = Query.Where(x => x.MarketplaceName == marketplaceName);
            }

            return this;
        }

        public virtual MarketpalceConnectionQueryBuilder SetByService(EnumProjectServices? projectService)
        {
            return this;
        }

        public virtual MarketpalceConnectionQueryBuilder SetByType(MarketplaceConnectionType? type)
        {
            if (type == null)
            {
                return this;
            }

            Query = Query.Where(x => x.ConnectionType == type.Value);

            return this;
        }
    }
}
