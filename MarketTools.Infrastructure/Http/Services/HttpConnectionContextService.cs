using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Services
{
    internal class HttpConnectionContextService : IHttpConnectionContextService
    {
        private readonly IList<MarketplaceConnectionEntity> _connections = new List<MarketplaceConnectionEntity>();
        public MarketplaceConnectionEntity? GetOrDefault(MarketplaceName marketplaceName, MarketplaceConnectionType type)
        {
            return _connections.FirstOrDefault(x => x.MarketplaceName == marketplaceName && x.ConnectionType == type);
        }

        public MarketplaceConnectionEntity GetRequired(MarketplaceName marketplaceName, MarketplaceConnectionType type)
        {
            return _connections.FirstOrDefault(x => x.MarketplaceName == marketplaceName && x.ConnectionType == type)
                ?? throw new AppNotFoundException("Не установлен контекст подключения, для дальнейшей обработки запросов.");
        }

        public void Set(MarketplaceConnectionEntity connectionEntity)
        {
            MarketplaceConnectionEntity? oldConnenection = _connections.FirstOrDefault(x=> x.Id == connectionEntity.Id);
            if(oldConnenection != null)
            {
                _connections.Remove(oldConnenection);
            }

            _connections.Add(connectionEntity);
        }
    }
}
