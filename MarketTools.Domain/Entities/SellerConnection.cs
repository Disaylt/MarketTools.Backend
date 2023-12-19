using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class SellerConnection : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(300)]
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int NumConnectionsAttempt { get; set; }
        public DateTime LastBadConnectDate { get; set; }

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public AutoresponderStandardConnection AutoresponderConnection { get; set; } = new AutoresponderStandardConnection();
    }
}
