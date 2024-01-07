using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.BanWords.Queries.GetRange
{
    public class BanWordGetRangeQuery : IRequest<IEnumerable<StandardAutoresponderBanWordEntity>>
    {
        public int BlackListId { get; set; }
    }
}
