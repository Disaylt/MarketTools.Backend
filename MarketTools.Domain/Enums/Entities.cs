﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Enums
{
    public enum MarketplaceName
    {
        WB = 1,
        OZON
    }

    public enum AutoresponderColumnType
    {
        Standard = 1,
        Recommendation
    }

    public enum EnumProjectServices
    {
        StandardAutoresponder = 1
    }

    public enum OrderType
    {
        Ask,
        Desk,
        None
    }
}
