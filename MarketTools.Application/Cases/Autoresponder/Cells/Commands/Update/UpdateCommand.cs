using MarketTools.Application.Cases.Autoresponder.Cells.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Cells.Commands.Update
{
    public class UpdateCommand : IRequest<CellVm>
    {
        public int Id { get; set; }
        public required string Value { get; set; }
    }
}
