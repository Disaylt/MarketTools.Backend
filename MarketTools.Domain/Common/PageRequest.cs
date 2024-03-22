using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Common
{
    public class PageRequest
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public OrderType OrderType { get; set; } = OrderType.Asc;
    }
}
