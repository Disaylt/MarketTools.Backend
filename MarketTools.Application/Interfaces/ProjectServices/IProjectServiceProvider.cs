﻿using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Services
{
    public interface IProjectServiceProvider<T>
    {
        public T Create(EnumProjectServices projectServices);
    }
}
