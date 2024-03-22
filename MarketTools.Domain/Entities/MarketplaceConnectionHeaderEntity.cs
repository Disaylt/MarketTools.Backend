using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    [Index(nameof(ConnectionId), nameof(Name), IsUnique = true)]
    public class MarketplaceConnectionHeaderEntity : HeaderEntity
    {
        public int ConnectionId { get; set; }
        public MarketplaceConnectionEntity Connection { get; set; } = null!;
    }
}
