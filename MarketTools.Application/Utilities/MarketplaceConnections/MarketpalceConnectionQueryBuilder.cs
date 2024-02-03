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
        private MarketplaceName? _marketplaceName;

        public MarketpalceConnectionQueryBuilder(IQueryable<MarketplaceConnectionEntity> query) : base(query)
        {

        }

        public override MarketpalceConnectionQueryBuilder SetPagination(PageRequest? pageRequest)
        {
            base.SetPagination(pageRequest);

            return this;
        }

        public virtual MarketpalceConnectionQueryBuilder SetMarketplace(MarketplaceName? marketplaceName)
        {
            if (marketplaceName != null)
            {
                _marketplaceName = marketplaceName;
                Query = Query.Where(x=> x.MarketplaceName == marketplaceName);
            }

            return this;
        }

        public virtual MarketpalceConnectionQueryBuilder SetByService(IMarketplaceConnectionFactory marketplaceConnectionFactory, ProjectServices? projectService)
        {
            if(projectService == null) 
            {
                return this;
            }

            if (_marketplaceName == null)
            {
                throw new AppBadRequestException("Для выбора подключений по сервису необходимо указать название маркетплейса.");
            }

            string discriminator = marketplaceConnectionFactory.Create(_marketplaceName.Value)
                .Select(projectService.Value)
                .Determinant();

            Query = Query.Where(x=> x.Discriminator == discriminator);

            return this;
        }

        public virtual MarketpalceConnectionQueryBuilder SetByType(MarketplaceConnectionType? type)
        {
            if (type == null)
            {
                return this;
            }

            string discriminator = new ConnectionTypeFactory().Get(type.Value);
            Query = Query.Where(x=> x.Discriminator == discriminator);

            return this;
        }
    }
}
