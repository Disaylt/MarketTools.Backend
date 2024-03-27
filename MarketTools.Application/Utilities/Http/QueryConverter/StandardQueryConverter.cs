using MarketTools.Application.Utilities.Http.HttpQueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.Http.QueryConverter
{
    public class StandardQueryConverter : BaseQueryConverter
    {
        protected virtual void SetTake(int? value)
        {
            if (value.HasValue)
            {
                string key = "take";

                AddParam(key, value.Value.ToString());
            }
        }

        protected virtual void SetSkip(int? value)
        {
            if (value.HasValue)
            {
                string key = "skip";

                AddParam(key, value.Value.ToString());
            }
        }
    }
}
