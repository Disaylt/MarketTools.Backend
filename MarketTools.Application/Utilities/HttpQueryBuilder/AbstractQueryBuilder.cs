using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.HttpParamsBuilder
{
    public class AbstractQueryBuilder
    {
        protected IDictionary<string, string> KeyAndValueParams { get; }

        public AbstractQueryBuilder()
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

        public virtual string Build()
        {
            IEnumerable<string> paramsList = KeyAndValueParams
                .Select(x => $"{x.Key}={x.Value}");

            StringBuilder sb = new StringBuilder();
            sb.AppendJoin('&', paramsList);

            return sb.ToString();
        }
    }
}
