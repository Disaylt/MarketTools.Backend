using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Builders.Requests
{
    internal class BaseQueryBuilder<TEntity>
        where TEntity : BaseEntity
    {
        protected IQueryable<TEntity> Query { get; set; }

        public BaseQueryBuilder(IQueryable<TEntity> query)
        {
            Query = query;
        }

        public IQueryable<TEntity> Build()
        {
            return Query;
        }

        public virtual BaseQueryBuilder<TEntity> SetPagination(PageRequest? pageRequest)
        {
            if (pageRequest == null)
            {
                return this;
            }

            switch (pageRequest.OrderType)
            {
                case OrderType.Ask:
                    Query = Query.OrderBy(x => x.Id);
                    break;
                case OrderType.Desk:
                    Query = Query.OrderByDescending(x => x.Id);
                    break;
            }

            Query = Query
                .Skip(pageRequest.Skip)
                .Take(pageRequest.Take);

            return this;
        }
    }
}
