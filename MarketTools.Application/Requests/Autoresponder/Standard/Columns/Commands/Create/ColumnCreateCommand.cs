using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Columns.Commands.Create
{
    public class ColumnCreateCommand : IRequest<StandardAutoresponderColumnEntity>
    {
        public string Name { get; set; } = null!;
        public AutoresponderColumnType Type { get; set; }
    }
}
