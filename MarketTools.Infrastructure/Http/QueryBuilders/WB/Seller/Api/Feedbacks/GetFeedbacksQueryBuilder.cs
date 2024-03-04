using MarketTools.Application.Utilities.HttpParamsBuilder;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.QueryBuilders.WB.Seller.Api.Feedbacks
{
    internal class GetFeedbacksQueryBuilder : AbstractQueryBuilder
    {
        public GetFeedbacksQueryBuilder IsAnswered(bool value)
        {
            string key = "isAnswered";

            AddParam(key, value.ToString());

            return this;
        }

        public GetFeedbacksQueryBuilder Take(int value)
        {
            string key = "take";

            AddParam(key, value.ToString());

            return this;
        }

        public GetFeedbacksQueryBuilder Skip(int value)
        {
            string key = "skip";

            AddParam(key, value.ToString());

            return this;
        }

        public GetFeedbacksQueryBuilder Order(OrderType value)
        {
            string? strValue = SelectOrder(value);

            if(strValue != null)
            {
                string key = "order";


                AddParam(key, strValue);
            }

            return this;
        }

        public GetFeedbacksQueryBuilder NmId(int? value)
        {
            if (value.HasValue)
            {
                string key = "nmId";

                AddParam(key, value.Value.ToString());
            }

            return this;
        }

        public GetFeedbacksQueryBuilder DateFrom(int? value)
        {
            if (value.HasValue)
            {
                string key = "dateFrom";

                AddParam(key, value.Value.ToString());
            }

            return this;
        }

        public GetFeedbacksQueryBuilder DateTo(int? value)
        {
            if (value.HasValue)
            {
                string key = "dateTo";

                AddParam(key, value.Value.ToString());
            }

            return this;
        }

        private string? SelectOrder(OrderType value)
        {
            return value switch
            {
                OrderType.Desc => "dateDesc",
                OrderType.Asc => "dateAsc",
                _ => null
            } ;
        }
    }
}
