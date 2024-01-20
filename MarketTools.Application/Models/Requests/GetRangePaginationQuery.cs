using MarketTools.Application.Interfaces.Requests;
using MarketTools.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Requests
{
    public class GetRangePaginationQuery<T> : IGetRangeQuery<T>
    {
        public PageRequest? PageRequest { get; set; }
    }
}
