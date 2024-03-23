using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Domain.Enums;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAutoresponder.WorkerService.Jobs
{
    [DisallowConcurrentExecution]
    internal class OzonAutoresponderJob : AutoresponderJob
    {
        public OzonAutoresponderJob(IAutoresponderConnectionsService _autoresponderConnectionsService, 
            IServiceProvider _serviceProvider, 
            ILogger<WbAutoresponderJob> _logger) 
            : base(_autoresponderConnectionsService, _serviceProvider, _logger, MarketplaceName.OZON, 10)
        {
        }
    }
}
