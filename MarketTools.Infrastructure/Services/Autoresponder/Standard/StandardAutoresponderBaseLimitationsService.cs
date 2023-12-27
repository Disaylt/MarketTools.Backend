using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Autoresponder.Standard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Services.Autoresponder.Standard
{
    internal class StandardAutoresponderBaseLimitationsService : IStandardAutoresponderLimitationsService
    {
        public Task<StandardAutoresponderLimitsDto> GetAsync()
        {
            return Task.FromResult(new StandardAutoresponderLimitsDto());
        }
    }
}
