using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Requests
{
    public interface IGetRangePaginationQuery<out T> : IRequest<IEnumerable<T>>
    {
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
