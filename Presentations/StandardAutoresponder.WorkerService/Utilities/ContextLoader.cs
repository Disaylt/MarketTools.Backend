using MarketTools.Application.Interfaces.Autoresponder.Standard;
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
    internal class ContextLoader(IConnectionServiceFactory<IConnectionSerivceDeterminant> _connectionServiceFactory,
        IHttpConnectionContextWriter _httpConnectionContextWriter,
        IUnitOfWork _unitOfWork,
        IAuthWriteHelper _authWriteHelper,
        IAutoresponderContextService _autoresponderContextService,
        IAutoresponderContextWriter _autoresponderContextWriter)
        : IContextLoader
    {
        public async Task Handle(MarketplaceName marketplaceName, int connectionId)
        {
            MarketplaceConnectionEntity connection = await _connectionServiceFactory
                .Create(MarketplaceName.WB)
                .Create(EnumProjectServices.StandardAutoresponder)
                .GetAsync(_unitOfWork, connectionId);

            _httpConnectionContextWriter.Write(connection);
            _authWriteHelper.Set(connection.UserId);

            AutoresponderContext autoresponderContext = await _autoresponderContextService.Create(connectionId);
            _autoresponderContextWriter.Write(autoresponderContext);
        }
    }
}
