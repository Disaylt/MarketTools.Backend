using MarketTools.Application.Common.Builders.Requests;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Reports.Utilities
{
    internal class ReportsQueryBuilder : BaseQueryBuilder<StandardAutoresponderNotificationEntity>
    {
        public ReportsQueryBuilder(IQueryable<StandardAutoresponderNotificationEntity> query) : base(query)
        {
        }

        public ReportsQueryBuilder SetConnectionId(int? connectionId)
        {
            if (connectionId.HasValue)
            {
                Query = Query.Where(x => x.StandardAutoresponderConnectionId == connectionId.Value);
            }

            return this;
        }

        public ReportsQueryBuilder SetRating(int? rating)
        {
            if (rating.HasValue)
            {
                Query = Query.Where(x => x.Rating == rating.Value);
            }

            return this;
        }

        public ReportsQueryBuilder SetSuccesStatus(bool? isSuccess)
        {
            if (isSuccess.HasValue)
            {
                Query = Query.Where(x => x.IsSuccess == isSuccess.Value);
            }

            return this;
        }

        public ReportsQueryBuilder SetArticle(string? article)
        {
            if (string.IsNullOrEmpty(article))
            {
                return this;
            }

            Query = Query.Where(x => x.Article == article || x.SupplierArticle == article);

            return this;
        }
    }
}
