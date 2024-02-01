using MarketTools.Application.Common.Builders;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.MarketplaceConnections
{
    internal class MarketpalceConnectionQueryBuilder : BaseQueryBuilder<MarketplaceConnectionEntity>
    {
        private readonly MarketplaceName? _marketplaceName;
        private readonly IConnectionTypeFactory _connectionTypeFactory;

        public MarketpalceConnectionQueryBuilder(IQueryable<MarketplaceConnectionEntity> query, MarketplaceName? marketplaceName) : base(query)
        {
            _marketplaceName = marketplaceName;
            _connectionTypeFactory = new ConnectionTypeFactory();
        }

        public override MarketpalceConnectionQueryBuilder SetPagination(PageRequest? pageRequest)
        {
            base.SetPagination(pageRequest);

            return this;
        }

        public virtual MarketpalceConnectionQueryBuilder SetMarketplace()
        {
            if (_marketplaceName != null)
            {
                Query = Query.Where(x=> x.MarketplaceName == _marketplaceName);
            }

            return this;
        }

        public virtual MarketpalceConnectionQueryBuilder SetByService(ProjectServices? projectService)
        {
            if(projectService == null) 
            {
                return this;
            }

            if (_marketplaceName == null)
            {
                throw new AppBadRequestException("Для выбора подключений по сервису необходимо указать название маркетплейса.");
            }

            switch(_marketplaceName.Value)
            {
                case MarketplaceName.WB:
                    Query = new WbServiceConnectionFactory(Query, _connectionTypeFactory)
                        .Select(projectService.Value);
                    break;
            }

            return this;
        }

        public virtual MarketpalceConnectionQueryBuilder SetByType(MarketplaceConnectionType? type)
        {
            if (type == null)
            {
                return this;
            }

            string discriminator = _connectionTypeFactory.Get(type.Value);
            Query = Query.Where(x=> x.Discriminator == discriminator);

            return this;
        }
    }
}
