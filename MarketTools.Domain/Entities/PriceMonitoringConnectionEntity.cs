using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class PriceMonitoringConnectionEntity : BaseServiceConnectionEntity
    {
        public List<PriceMonotoringProductEntity> Products { get; set; } = new List<PriceMonotoringProductEntity>();
        public List<PriceMonitoringReportEntity> Reports { get; set; } = new List<PriceMonitoringReportEntity>();
    }
}
