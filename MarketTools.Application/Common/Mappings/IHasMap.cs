﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MarketTools.Application.Common.Mappings
{
    public interface IHasMap
    {
        void Mapping(Profile profile);
    }
}
