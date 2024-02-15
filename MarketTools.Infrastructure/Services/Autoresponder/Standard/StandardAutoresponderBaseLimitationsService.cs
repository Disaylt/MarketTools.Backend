using MarketTools.Application.Interfaces.Common;
using MarketTools.Domain.Interfaces.Limits;
using MarketTools.Infrastructure.Services.Autoresponder.Standard.Models;
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
            IStandarAutoresponderLimits value = new StandardAutoresponderLimitsModel();

            return Task.FromResult(value);
        }
    }
}
