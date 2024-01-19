using MarketTools.Application.Interfaces.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Requests
{
    public class GetRangePaginationQuery<T> : IGetRangePaginationQuery<T>
    {
        public int Take {  get; set; }
        public int Skip { get; set; }
    }
}
