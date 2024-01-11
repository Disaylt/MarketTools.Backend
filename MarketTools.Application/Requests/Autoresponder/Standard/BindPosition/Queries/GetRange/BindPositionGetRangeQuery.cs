using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ColumnBindPosition.Queries.GetRange
{
    public class BindPositionGetRangeQuery : IRequest<IEnumerable<StandardAutoresponderColumnBindPositionEntity>>
    {
        public int TemplateId { get; set; }
        public AutoresponderColumnType ColumnType { get; set; }
    }
}
