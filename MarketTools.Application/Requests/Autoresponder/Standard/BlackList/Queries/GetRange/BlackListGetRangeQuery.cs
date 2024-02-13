using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.Queries.GetRange
{
    public class BlackListGetRangeQuery
        : IRequest<IEnumerable<StandardAutoresponderBlackListEntity>>
    {
        
    }
}
