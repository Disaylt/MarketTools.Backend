using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http.Wb
{
    public interface IWbHttpRequestFactory<T>
    {
        public T Create(MarketplaceConnectionType type);
    }
}
