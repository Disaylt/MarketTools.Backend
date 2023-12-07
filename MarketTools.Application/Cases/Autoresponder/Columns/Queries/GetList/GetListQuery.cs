using MarketTools.Application.Cases.Autoresponder.Columns.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Columns.Queries.GetList
{
    public class GetListQuery : IRequest<IEnumerable<ColumnVm>>
    {

    }
}
