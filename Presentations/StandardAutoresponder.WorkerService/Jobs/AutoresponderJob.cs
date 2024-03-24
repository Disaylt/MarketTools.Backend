using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Interfaces.MarketplaceConnections;
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
    internal abstract class AutoresponderJob(IAutoresponderConnectionsService _autoresponderConnectionsService, 
        IServiceProvider _serviceProvider,
        ILogger _logger,
        MarketplaceName _marketplaceName,
        int _maxTasks = 10) 
        : IJob
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(_maxTasks);

        public async Task Execute(IJobExecutionContext context)
        {
            IEnumerable<StandardAutoresponderConnectionEntity> activeConnections = await _autoresponderConnectionsService
                .GetRangeForHandleAsync(_marketplaceName, context.CancellationToken);

            List<Task> tasks = new List<Task>();

            foreach (var activeConnection in activeConnections)
            {
                Task task = HandleConnection(activeConnection.SellerConnectionId);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

            _logger.LogInformation($"Выполнено {activeConnections.Count()} подключение для {_marketplaceName}");
        }

        private async Task HandleConnection(int connectionId)
        {
            await _semaphoreSlim.WaitAsync();
            using IServiceScope serviceScope = _serviceProvider.CreateScope();
            try
            {
                await serviceScope.ServiceProvider
                    .GetRequiredService<IIdentityContextLoadService>()
                    .LoadByConnection(connectionId);

                await serviceScope
                    .ServiceProvider
                    .GetRequiredService<IAreaServiceFactory<IAutoresponderHandler>>()
                    .Create(_marketplaceName)
                    .RunAsync(connectionId);

                _logger.LogInformation($"Id: {connectionId} успешно завершен.");
            }
            catch (AppConnectionBadRequestException ex)
            {
                await serviceScope.ServiceProvider
                    .GetRequiredService<IExceptionHandleService<AppConnectionBadRequestException>>()
                    .Hadnle(ex);
            }
            catch (Exception ex)
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
