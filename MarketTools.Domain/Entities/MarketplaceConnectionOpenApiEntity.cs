using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class MarketplaceConnectionOpenApiEntity : MarketplaceConnectionEntity
    {
        [MaxLength(1000)]
        public string Token { get; set; } = string.Empty;
    }
}
