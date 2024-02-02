using MarketTools.Application.Utilities.MarketplaceConnections;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http
{
    public interface IHttpConnectionFactory<out T>
    {
        public T Create(MarketplaceConnectionEntity connection);
    }
}
