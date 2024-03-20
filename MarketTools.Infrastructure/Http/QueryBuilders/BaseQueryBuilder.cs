using MarketTools.Application.Utilities.Http.HttpQueryBuilder;
using MarketTools.Domain.Enums;
using MarketTools.Infrastructure.Http.QueryBuilders.WB.Seller.Api.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.QueryBuilders
{
    internal class BaseQueryBuilder : AbstractQueryBuilder
    {
        public virtual BaseQueryBuilder Take(int value)
        {
            string key = "take";

            AddParam(key, value.ToString());

            return this;
        }

        public virtual BaseQueryBuilder Skip(int value)
        {
            string key = "skip";

            AddParam(key, value.ToString());

            return this;
        }

        public virtual BaseQueryBuilder Sort(OrderType value)
        {
            string? strValue = SelectOrder(value);

            if (strValue != null)
            {
                string key = "sort";


                AddParam(key, strValue);
            }

            return this;
        }

        private string? SelectOrder(OrderType value)
        {
            return value switch
            {
                OrderType.Desc => "desc",
                OrderType.Asc => "asc",
                _ => null
            };
        }
    }
}
