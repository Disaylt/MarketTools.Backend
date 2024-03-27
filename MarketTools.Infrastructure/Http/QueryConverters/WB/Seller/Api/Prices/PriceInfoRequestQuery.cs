using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Models.Http.WB.Seller.Api.Prices;
using MarketTools.Application.Utilities.Http.QueryConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.QueryConverters.WB.Seller.Api.Prices
{
    internal class WbSellerApiPriceInfoRequestQuery : StandardQueryConverter, IHttpQueryConverter<PriceProductRequestQuery>
    {
        public string Convert(PriceProductRequestQuery query)
        {
            SetRequiredTake(query.Take);
            SetSkip(query.Skip);
            SetArticle(query.Article);

            return Convert();
        }

        protected override void SetSkip(int? value)
        {
            if (value.HasValue)
            {
                string key = "offset";
                AddParam(key, value.Value.ToString());
            }
        }

        protected virtual void SetRequiredTake(int value)
        {
            string key = "limit";
            AddParam(key, value.ToString());
        }

        protected virtual void SetArticle(string? value)
        {
            if(value != null)
            {
                string key = "filterNmID";
                AddParam(key, value);
            }
        }
    }
}
