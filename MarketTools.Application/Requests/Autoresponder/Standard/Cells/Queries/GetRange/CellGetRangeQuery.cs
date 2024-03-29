﻿using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Cells.Queries.GetRange
{
    public class CellGetRangeQuery : IRequest<IEnumerable<StandardAutoresponderCellEntity>>
    {
        public int CollumnId { get; set; }
    }
}
