using MarketTools.Domain.Interfaces.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.HttpParamsBuilder.WB.Seller
{
    internal class WbSellerGetFeedbacksParamBuilder : AbstractParamsBuilder
    {
        public void IsAnswered(bool value)
        {
            string key = "isAnswered";

            AddParam(key, value.ToString());
        }

        public void Take(int value)
        {
            string key = "take";

            AddParam(key, value.ToString());
        }

        public void Skip(int value)
        {
            string key = "skip";

            AddParam(key, value.ToString());
        }

        public void Order(string value)
        {
            string key = "order";

            AddParam(key, value.ToString());
        }

        public void NmId(int? value)
        {
            if (value.HasValue)
            {
                string key = "nmId";

                AddParam(key, value.Value.ToString());
            }
        }

        public void DateFrom(int? value)
        {
            if (value.HasValue)
            {
                string key = "dateFrom";

                AddParam(key, value.Value.ToString());
            }
        }

        public void DateTo(int? value)
        {
            if (value.HasValue)
            {
                string key = "dateTo";

                AddParam(key, value.Value.ToString());
            }
        }
    }
}
