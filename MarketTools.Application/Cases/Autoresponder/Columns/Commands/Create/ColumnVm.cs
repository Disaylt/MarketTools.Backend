﻿using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Columns.Commands.Create
{
    public class ColumnVm : IHasMap
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AutoresponderColumn, ColumnVm>();
        }
    }
}
