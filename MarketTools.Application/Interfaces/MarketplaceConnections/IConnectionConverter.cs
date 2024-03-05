using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.MarketplaceConnections
{
    public interface IConnectionConverter<T> where T : AbstractConnection
    {
        public T Convert(MarketplaceConnectionEntity connection);
        public void UpdateDetails(MarketplaceConnectionEntity connection, T concreteConnection);
    }
}
