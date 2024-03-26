using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class PriceMonitoringReportEntity : BaseEntity
    {
        public int ConnectionId { get; set; }
        public PriceMonitoringConnectionEntity Connection { get; set; } = null!;
    }
}
