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
    internal class WbAutoresponderJob(IAutoresponderConnectionsService _autoresponderConnectionsService, IServiceProvider _serviceProvider, ILogger<WbAutoresponderJob> _logger) : IJob
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
                    .GetRequiredService<IIdentityContextLoadService>()
                    .LoadByConnection(connectionId);

                await serviceScope
                    .ServiceProvider
                    .GetRequiredService<IAutoresponderHandler>()
                    .RunAsync(connectionId);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Bad execute connection - {connectionId}");
            }
            finally 
            {
                _semaphoreSlim.Release();
            }
        }
    }
}
