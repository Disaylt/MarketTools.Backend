using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api
{
    public interface IWbSellerApiConnectionConverter : IBaseConnectionConverter
    {
        public void Change(string token);
    }
}
