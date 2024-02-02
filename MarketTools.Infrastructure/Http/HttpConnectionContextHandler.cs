using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http
{
    internal class HttpConnectionContextHandler : IHttpConnectionContextReader, IHttpConnectionContextWriter
    {
        private readonly List<MarketplaceConnectionEntity> _connections = new List<MarketplaceConnectionEntity>();

        public T Read<T>() where T : MarketplaceConnectionEntity
        {
            return _connections.FirstOrDefault(x => x.GetType() == typeof(T)) as T
                ?? throw new AppNotFoundException("Http клиент с таким типом не найден.");
        }

        public void Write<T>(T entity) where T : MarketplaceConnectionEntity
        {
            _connections.Add(entity);
        }
    }
}
