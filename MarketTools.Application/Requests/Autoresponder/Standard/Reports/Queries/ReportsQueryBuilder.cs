using MarketTools.Application.Common.Builders;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Reports.Queries
{
    internal class ReportsQueryBuilder : BaseQueryBuilder<StandardAutoresponderNotificationEntity>
    {
        public ReportsQueryBuilder(IQueryable<StandardAutoresponderNotificationEntity> query) : base(query)
        {
        }

        public ReportsQueryBuilder SetConnectionId(int? connectionId)
        {
            if(connectionId.HasValue)
            {
                Query = Query.Where(x=> x.StandardAutoresponderConnectionId == connectionId.Value);
            }

            return this;
        }
    }
}
