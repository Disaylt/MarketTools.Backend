using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Enums
{
    public enum MarketplaceName
    {
        WB = 1,
        OZON,
        Telegram
    }

    public enum AutoresponderColumnType
    {
        Standard = 1,
        Recommendation
    }

    public enum EnumProjectServices
    {
        StandardAutoresponder = 1,
        PriceMonitoring
    }

    public enum MarketplaceConnectionType
    {
        OpenApi = 1,
        Account,
        None
    }

    public enum OrderType
    {
        Asc,
        Desc,
        None
    }
}
