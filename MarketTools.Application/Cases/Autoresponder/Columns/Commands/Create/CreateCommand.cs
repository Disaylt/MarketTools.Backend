﻿using MarketTools.Application.Cases.Autoresponder.Columns.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Columns.Commands.Create
{
    public class CreateCommand : IRequest<ColumnVm>
    {
        public string Name { get; set; } = null!;
    }
}