using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    [Index(nameof(ConnectionId), nameof(Name), nameof(Domain), IsUnique = true)]
    public class MarketplaceConnectionCookieEntity : CookieEntity
    {
        public int ConnectionId { get; set; }
        public MarketplaceConnectionEntity Connection { get; set; } = null!;
    }
}
