using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Builders
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
            if(pageRequest != null)
            {
                Query = Query
                    .OrderBy(x => x.Id)
                    .Skip(pageRequest.Skip)
                    .Take(pageRequest.Take);
            }

            return this;
        }
    }
}
