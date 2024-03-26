using MarketTools.Domain.Enums;
using MarketTools.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class MarketplaceConnectionEntity : BaseEntity
    {
        [MaxLength(1000)]
        public string Name { get; set; } = null!;
        public string? Discriminator { get; set; }

        [Required]
        [Range(1, 999)]
        public MarketplaceName MarketplaceName { get; set; } = 0;

        [Required]
        [Range(1, 999)]
        [DefaultValue(1)]
        public MarketplaceConnectionType ConnectionType { get; set; } = 0;

        [MaxLength(300)]
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int NumConnectionsAttempt { get; set; }
        public DateTime LastBadConnectDate { get; set; }

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public StandardAutoresponderConnectionEntity AutoresponderConnection { get; set; } = new StandardAutoresponderConnectionEntity();
        public PriceMonitoringConnectionEntity PriceMonitoringConnection { get; set; } = new PriceMonitoringConnectionEntity();

        public List<MarketplaceConnectionHeaderEntity> Headers { get; set; } = new List<MarketplaceConnectionHeaderEntity>();
        public List<MarketplaceConnectionCookieEntity> Cookies { get; set; } = new List<MarketplaceConnectionCookieEntity>();
    }
}
