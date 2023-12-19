using MarketTools.Application.Cases.Autoresponder.Standard.Columns.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Columns.Queries.GetRange
{
    public class GetRangeQuery : IRequest<IEnumerable<ColumnVm>>
    {

    }
}
