using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class PriceMonotoringProductEntity : BaseEntity
    {
        [DefaultValue("Неизвестно")]
        public string Name { get; set; } = "Неизвестно";
        public string Article { get; set; } = "";
        public string SellerArticle { get; set; } = "";

        public int ConnectionId { get; set; }
        public PriceMonitoringConnectionEntity Connection { get; set; } = null!;
    }
}
