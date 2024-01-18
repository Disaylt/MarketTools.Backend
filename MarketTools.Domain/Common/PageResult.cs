using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Common
{
    public class PageResult<T>
    {
        public int Total { get; }
        public IEnumerable<T> Items { get; }

        public PageResult(int total, IEnumerable<T> items)
        {
            Total = total;
            Items = items;
        }
    }
}
