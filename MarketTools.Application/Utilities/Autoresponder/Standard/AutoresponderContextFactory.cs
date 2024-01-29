using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.Autoresponder.Standard
{
    public class AutoresponderContextFactory(IAutoresponderContextService _autoresponderContextService)
        : IAutoresponderContextFactory
    {
        private readonly IDictionary<int, AutoresponderContext> _connectionIdAndContext = new 
            Dictionary<int, AutoresponderContext>();

        public async Task<AutoresponderContext> GetAsync(int connectionId)
        {
            if(_connectionIdAndContext.ContainsKey(connectionId))
            {
                return _connectionIdAndContext[connectionId];
            }

            AutoresponderContext context = await _autoresponderContextService.CreateAsync(connectionId);
            _connectionIdAndContext.Add(connectionId, context);

            return context;
        }
    }
}
