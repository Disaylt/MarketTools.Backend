using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using StandardAutoresponder.WorkerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StandardAutoresponder.WorkerService.Utilities
{
    internal class ContextLoader(IAutoresponderContextLoadService _autoresponderContextService,
        IContextService<AutoresponderContext> _autoresponderContext)
        : IContextLoader
    {
        public async Task Handle(MarketplaceName marketplaceName, int connectionId)
        {
            _autoresponderContext.Context = await _autoresponderContextService.Create(connectionId);
        }
    }
}
