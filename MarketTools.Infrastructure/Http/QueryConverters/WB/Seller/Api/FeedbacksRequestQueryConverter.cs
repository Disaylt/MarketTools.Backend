using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Models.Http.WB.Seller.Api.Feedbacks;
using MarketTools.Application.Utilities.Http.HttpQueryBuilder;
using MarketTools.Application.Utilities.Http.QueryConverter;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.QueryConverters.WB.Seller.Api
{
    internal class WbSellerApiFeedbacksRequestQueryConverter : StandardQueryConverter, IHttpQueryConverter<WbSellerApiFeedbacksQuery>
    {
        public virtual string Convert(WbSellerApiFeedbacksQuery query)
        {
            SetAnswered(query.IsAnswered);
            SetSort(query.Order);
            SetNmId(query.NmId);
            SetDateFrom(query.DateFrom);
            SetDateTo(query.DateTo);
            SetTake(query.Take);
            SetSkip(query.Skip);

            return Convert();
        }



        protected virtual void SetDateTo(long? value)
        {
            if (value.HasValue)
            {
                string key = "dateTo";

                AddParam(key, value.Value.ToString());
            }
        }

        protected virtual void SetDateFrom(long? value)
        {
            if (value.HasValue)
            {
                string key = "dateFrom";

                AddParam(key, value.Value.ToString());
            }
        }

        protected virtual void SetNmId(int? value)
        {
            if (value.HasValue)
            {
                string key = "nmId";

                AddParam(key, value.Value.ToString());
            }
        }

        protected virtual void SetSort(OrderType value)
        {
            string? strValue = value switch
            {
                OrderType.Desc => "dateDesc",
                OrderType.Asc => "dateAsc",
                _ => null
            };

            if(strValue != null )
            {
                string key = "order";
                AddParam(key, strValue);
            }
        }

        protected virtual void SetAnswered(bool value)
        {
            string key = "isAnswered";
            AddParam(key, value.ToString());
        }
    }
}
