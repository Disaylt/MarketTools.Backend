﻿using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.MarketplaceConnections
{
    public interface IConnectionDefinitionService
    {
        public MarketplaceConnectionType Get(MarketplaceName marketplaceName, EnumProjectServices service);
    }
}
