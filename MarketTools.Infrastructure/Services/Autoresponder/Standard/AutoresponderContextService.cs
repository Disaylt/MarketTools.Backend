using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Services.Autoresponder.Standard
{
    internal class AutoresponderContextService<T> : IAutoresponderContextService<T> where T : MarketplaceConnectionEntity
    {
        private AutoresponderContext? _context;

        public AutoresponderContext CreateContext(int connectionId)
        {
            if (_context != null)
            {
                return _context;
            }

            throw new InvalidOperationException();
        }


    }
}
