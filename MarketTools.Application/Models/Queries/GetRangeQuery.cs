using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
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
        public static implicit operator GetRangeQuery<T>(GetRangeQuery<WbSellerOpenApiConnectionEntity> v)
        {
            throw new NotImplementedException();
        }
    }
}
