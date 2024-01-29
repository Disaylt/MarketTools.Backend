using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Autoresponder.Standard
{
    public interface IAutoresponderContextService
    {
        public Task<AutoresponderContext> CreateContextAsync(int connectionId, MarketplaceName marketplaceName);
    }
}
