using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.Http.HttpQueryBuilder
{
    public class BaseQueryConverter
    {
        protected IDictionary<string, string> KeyAndValueParams { get; }

        public BaseQueryConverter()
        {
            KeyAndValueParams = new Dictionary<string, string>();
        }

        protected void AddParam(string key, string value)
        {
            if (KeyAndValueParams.ContainsKey(key))
            {
                KeyAndValueParams[key] = value;
            }
            else
            {
                KeyAndValueParams.Add(key, value);
            }
        }

        protected virtual string Convert()
        {
            IEnumerable<string> paramsList = KeyAndValueParams
                .Select(x => $"{x.Key}={x.Value}");

            return new StringBuilder()
                .AppendJoin('&', paramsList)
                .ToString();
        }
    }
}
