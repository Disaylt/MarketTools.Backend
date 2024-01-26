using MarketTools.Application.Common.Builders;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.MarketplaceConnections
{
    internal class MarketpalceConnectionQueryBuilder : BaseQueryBuilder<MarketplaceConnectionEntity>
    {
        public MarketpalceConnectionQueryBuilder(IRepository<MarketplaceConnectionEntity> repository) : base(repository.GetAsQueryable())
        {
        }

        public override MarketpalceConnectionQueryBuilder SetPagination(PageRequest? pageRequest)
        {
            base.SetPagination(pageRequest);

            return this;
        }
    }
}
