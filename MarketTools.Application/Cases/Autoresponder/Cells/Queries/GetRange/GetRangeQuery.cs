using MarketTools.Application.Cases.Autoresponder.Cells.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Cells.Queries.GetList
{
    public class GetRangeQuery : IRequest<IEnumerable<CellVm>>
    {
        public int CollumnId { get; set; }
    }
}
