using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.MarketplaceConnections
{
    public static class MarketplaceNameConverter
    {
        public static string Convert(MarketplaceName marketplaceName)
        {
            return marketplaceName switch
            {
                MarketplaceName.OZON => "Ozon",
                MarketplaceName.WB => "WB",
                _ => "Неизветный маркетплейс"
            };
        }
    }
}
