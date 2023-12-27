using MarketTools.Application.Cases.Autoresponder.Standard.Columns.Models;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Columns.Commands.Create
{
    public class CreateCommand : IRequest<ColumnVm>
    {
        public string Name { get; set; } = null!;
        public AutoresponderColumnType Type { get; set; }
    }
}
