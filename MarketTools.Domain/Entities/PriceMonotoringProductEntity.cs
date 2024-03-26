using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class PriceMonotoringProductEntity : BaseEntity
    {
        [DefaultValue("Неизвестно")]
        public string Name { get; set; } = "Неизвестно";

        [Required]
        public string Article { get; set; } = null!;
        public string SellerArticle { get; set; } = "";

        public int ConnectionId { get; set; }
        public PriceMonitoringConnectionEntity Connection { get; set; } = null!;

        public List<PriceMonitoringSizeEntity> Sizes { get; set; } = new List<PriceMonitoringSizeEntity>();
    }
}
