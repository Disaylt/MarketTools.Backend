using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Services.Autroesponder.Standard
{
    internal class AutoresponderResponseBuilderService
        (IAutoresponderContextReader _autoresponderContextReader)
        : IAutoresponderResponseBuilderService
    {

        private readonly AutoresponderContext _context = _autoresponderContextReader.Context;

        public Task<string> BuildAsync(AutoresponderRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
