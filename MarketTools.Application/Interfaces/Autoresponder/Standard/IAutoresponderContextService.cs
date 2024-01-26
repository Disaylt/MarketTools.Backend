using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Autoresponder.Standard
{
    public interface IAutoresponderContextService<T> where T : MarketplaceConnectionEntity
    {
        public AutoresponderContext GetContext(int connectionId);
    }
}
