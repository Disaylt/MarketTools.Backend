using MarketTools.Domain.Interfaces.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.HttpParamsBuilder.WB.Seller
{
    public class WbSellerGetFeedbacksParamBuilder : AbstractParamsBuilder
    {
        public WbSellerGetFeedbacksParamBuilder IsAnswered(bool value)
        {
            string key = "isAnswered";

            AddParam(key, value.ToString());

            return this;
        }

        public WbSellerGetFeedbacksParamBuilder Take(int value)
        {
            string key = "take";

            AddParam(key, value.ToString());

            return this;
        }

        public WbSellerGetFeedbacksParamBuilder Skip(int value)
        {
            string key = "skip";

            AddParam(key, value.ToString());

            return this;
        }

        public WbSellerGetFeedbacksParamBuilder Order(string value)
        {
            string key = "order";

            AddParam(key, value.ToString());

            return this;
        }

        public WbSellerGetFeedbacksParamBuilder NmId(int? value)
        {
            if (value.HasValue)
            {
                string key = "nmId";

                AddParam(key, value.Value.ToString());
            }

            return this;
        }

        public WbSellerGetFeedbacksParamBuilder DateFrom(int? value)
        {
            if (value.HasValue)
            {
                string key = "dateFrom";

                AddParam(key, value.Value.ToString());
            }

            return this;
        }

        public WbSellerGetFeedbacksParamBuilder DateTo(int? value)
        {
            if (value.HasValue)
            {
                string key = "dateTo";

                AddParam(key, value.Value.ToString());
            }

            return this;
        }
    }
}
