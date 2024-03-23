using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using Microsoft.Extensions.Logging;
using Quartz;
using StandardAutoresponder.WorkerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAutoresponder.WorkerService.Jobs
{
    [DisallowConcurrentExecution]
    internal class WbAutoresponderJob
        : AutoresponderJob
    {
        public WbAutoresponderJob(IAutoresponderConnectionsService _autoresponderConnectionsService, 
            IServiceProvider _serviceProvider, 
            ILogger<WbAutoresponderJob> _logger) 
            : base(_autoresponderConnectionsService, _serviceProvider, _logger, MarketplaceName.WB, 10)
        {
        }
    }
}
