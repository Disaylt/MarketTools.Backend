﻿using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
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
    internal class WbAutoresponderJob(IAutoresponderConnectionsService _autoresponderConnectionsService, IServiceProvider _serviceProvider) : IJob
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(10);

        public async Task Execute(IJobExecutionContext context)
        {
            IEnumerable<StandardAutoresponderConnectionEntity> activeConnections = await _autoresponderConnectionsService
                .GetRangeForHandleAsync(MarketplaceName.WB, context.CancellationToken);

            List<Task> tasks = new List<Task>();

            foreach (var activeConnection in activeConnections)
            {
                Task task = HandleConnection(activeConnection.SellerConnectionId);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }

        private async Task HandleConnection(int connectionId)
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
                using IServiceScope serviceScope = _serviceProvider.CreateScope();

                await serviceScope.ServiceProvider
                    .GetRequiredService<IAuthWriteHelper>()
                    .SetByLoadConnectionAsync(connectionId);

                await serviceScope.ServiceProvider
                    .GetRequiredService<IContextLoader>()
                    .Handle(MarketplaceName.WB, connectionId);

                await serviceScope
                    .ServiceProvider
                    .GetRequiredService<IWbFeedbacksHandler>()
                    .RunAsync();
            }
            finally 
            {
                _semaphoreSlim.Release();
            }
        }
    }
}
