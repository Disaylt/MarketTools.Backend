﻿using MarketTools.Application.Cases.Autoresponder.Tempaltes.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Commands.Add
{
    public class AddTemplateCommand : IRequest<TemplateVm>
    {
        public required string Name { get; set; }
    }
}