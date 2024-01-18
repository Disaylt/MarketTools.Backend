using MarketTools.Application.Interfaces;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Autoresponder.Standard.Models;
using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Services.Autoresponder.Standard
{
    internal class StandardAutoresponderBaseLimitationsService : ILimitsService<IStandarAutoresponderLimits>
    {
        public Task<IStandarAutoresponderLimits> GetAsync()
        {
            IStandarAutoresponderLimits value = new StandardAutoresponderLimitsDto();

            return Task.FromResult(value);
        }
    }
}
