using MarketTools.Application.Interfaces.Autoresponder.Standard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Autoresponder.Standard
{
    public interface IStandardAutoresponderLimitationsService
    {
        public Task<StandardAutoresponderLimitsDto> GetAsync();
    }
}
