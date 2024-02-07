using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Domain.Entities;
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
    internal class WbAutoresponderJob(IAutoresponderConnectionsService _autoresponderConnectionsService) : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            IEnumerable<StandardAutoresponderConnectionEntity> activeConnections = await _autoresponderConnectionsService
                .GetRangeForHandleAsync(MarketplaceName.WB, context.CancellationToken);

            throw new NotImplementedException();
        }
    }
}
