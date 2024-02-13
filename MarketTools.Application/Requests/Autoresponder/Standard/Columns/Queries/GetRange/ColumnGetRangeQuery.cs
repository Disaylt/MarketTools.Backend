using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Columns.Queries.GetRange
{
    public class ColumnGetRangeQuery : IRequest<IEnumerable<StandardAutoresponderColumnEntity>>
    {
        public AutoresponderColumnType Type { get; set; }
    }
}
