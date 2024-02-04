using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Services.MarketplaceConnections
{
    internal class AutoresponderActivateValidator()
        : IServiceActivateValidator<StandardAutoresponderConnectionEntity>
    {
        public Task UseAsync(MarketplaceConnectionEntity marketplaceConnectionEntity)
        {
            throw new NotImplementedException();
        }
    }
}
