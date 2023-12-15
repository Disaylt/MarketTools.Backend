using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class WbOpenApiSellerConnection : SellerConnection
    {
        [MaxLength(1000)]
        public string Token { get; set; } = string.Empty;
    }
}
