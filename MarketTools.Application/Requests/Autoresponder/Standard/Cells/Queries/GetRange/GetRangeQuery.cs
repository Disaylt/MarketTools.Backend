using MarketTools.Application.Cases.Autoresponder.Standard.Cells.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Cells.Queries.GetRange
{
    public class GetRangeQuery : IRequest<IEnumerable<CellVm>>
    {
        public int CollumnId { get; set; }
    }
}
