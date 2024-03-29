﻿using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Cells.Commands.Create
{
    public class CellCreateCommand : IRequest<StandardAutoresponderCellEntity>
    {
        public int ColumnId { get; set; }
        public required string Value { get; set; }
    }
}
