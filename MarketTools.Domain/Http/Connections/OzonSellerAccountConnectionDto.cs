using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Http.Connections
{
    public class OzonSellerAccountConnectionDto
    {
        public required string RefreshToken { get; set; }
        public string Token { get; set; } = string.Empty;
        public int SellerId { get; set; }
    }
}
