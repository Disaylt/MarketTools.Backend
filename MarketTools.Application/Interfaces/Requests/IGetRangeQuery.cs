using MarketTools.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Requests
{
    public interface IGetRangeQuery<out T> : IRequest<IEnumerable<T>>
    {
        public PageRequest? PageRequest { get; set; }
    }
}
