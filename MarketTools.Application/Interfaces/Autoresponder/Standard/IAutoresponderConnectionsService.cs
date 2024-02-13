using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Autoresponder.Standard
{
    public interface IAutoresponderConnectionsService
    {
        public Task<IEnumerable<StandardAutoresponderConnectionEntity>> GetRangeForHandleAsync(MarketplaceName marketplaceName, CancellationToken cancellationToken = default);
    }
}
