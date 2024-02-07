using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAutoresponder.WorkerService.Interfaces
{
    internal interface IContextLoader
    {
        public Task Handle(MarketplaceName marketplaceName, int connectionId);
    }
}
