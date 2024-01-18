using MarketTools.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Queries
{
    public class GetRangeQuery<T> : PageRequest, IRequest<IEnumerable<T>>
    {

    }
}
