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
        private readonly Dictionary<Type, MarketplaceConnectionEntity> _connections = new Dictionary<Type, MarketplaceConnectionEntity>();

        public T Read<T>() where T : MarketplaceConnectionEntity
        {
            if (_connections.ContainsKey(typeof(T)) == false)
            {
                throw new AppNotFoundException("Http клиент с таким типом не найден.");
            }

            return _connections[typeof(T)] as T
                ?? throw new AppNotFoundException("Http клиент с таким типом не найден.");
        }

        public void Write<T>(T entity) where T : MarketplaceConnectionEntity
        {
            Type type = typeof(T);

            if (_connections.ContainsKey(type))
            {
                _connections[type] = entity;
            }
            else
            {
                _connections.Add(type, entity);
            }
        }
    }
}
