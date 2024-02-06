using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Http.WB.Seller.Api
{
    public class WbApiResult<TData>
    {
        public required TData Data { get; set; }
        public required bool Error { get; set; }
        public required string ErrorText { get; set; }
        public IEnumerable<string>? AdditionalErrors { get; set; }
    }
}
