using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.MarketplaceConnections
{
    public interface IConnectionActivator : IConnectionService
    {
        public Task ActivateAsync(MarketplaceConnectionEntity connection);
    }
}
