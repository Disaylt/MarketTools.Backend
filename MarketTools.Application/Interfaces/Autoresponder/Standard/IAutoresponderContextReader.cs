﻿using MarketTools.Application.Models.Autoresponder.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Autoresponder.Standard
{
    public interface IAutoresponderContextReader
    {
        public AutoresponderContext Context { get; }
    }
}
