using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Models.Http.WB.Buyer.Api.Products;
using MarketTools.Application.Utilities.Http.HttpQueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.QueryConverters.WB.Buyer.Api
{
    internal class WbBuyerApiProductsQueryConverter : BaseQueryConverter, IHttpQueryConverter<WbBuyerApiProductsRequestQuery>
    {
        public string Convert(WbBuyerApiProductsRequestQuery query)
        {
            SetArticles(query.Articles);
            string articlesParam = Convert();

            return $"appType=1&curr=rub&dest=-446086&spp=0&{articlesParam}";
        }

        protected virtual void SetArticles(IEnumerable<string> values)
        {
            int totalArticles = values.Count();
            if(totalArticles < 1 || totalArticles > 400)
            {
                throw new AppBadRequestException("Количество артикулов должно быть от 1 до 400.");
            }

            string key = "nm";
            string articles = new StringBuilder()
                .AppendJoin(';', values)
                .ToString();

            AddParam(key, articles);
        }
    }
}
