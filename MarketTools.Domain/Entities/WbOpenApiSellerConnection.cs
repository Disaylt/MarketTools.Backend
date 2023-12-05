using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class WbOpenApiSellerConnection : SellerConnection
    {
        public string Token { get; set; } = string.Empty;
    }
}
