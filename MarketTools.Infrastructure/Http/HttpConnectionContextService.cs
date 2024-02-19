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
    public class HttpConnectionContextService : IHttpConnectionContextService
    {
        private Dictionary<Type, MarketplaceConnectionEntity> _connections;

        public HttpConnectionContextService()
        {
            _connections = new Dictionary<Type, MarketplaceConnectionEntity>();
        }

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
            Type type = entity.GetType();

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
