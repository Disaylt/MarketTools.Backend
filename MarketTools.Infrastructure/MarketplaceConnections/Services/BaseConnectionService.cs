using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Infrastructure.MarketplaceConnections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services
{
    internal class BaseConnectionService : IBaseConnectionService
    {
        public bool IsChanged { get; protected set; }

        private MarketplaceConnectionEntity? _connection;
        public MarketplaceConnectionEntity Connection
        {
            set
            {
                _connection = value;
            }
            protected get
            {
                if(_connection == null)
                {
                    throw new AppNotFoundException("Подключение не установлено.");
                }
                return _connection;
            }
        }

        protected void AddOrUpdateHeader(string key, string value)
        {

            MarketplaceConnectionHeaderEntity? header = Connection
                .Headers
                .FirstOrDefault(x => x.Name == key);

            if (header is null)
            {
                header = new MarketplaceConnectionHeaderEntity
                {
                    Name = key,
                    Value = value
                };
                Connection.Headers.Add(header);
            }
            else
            {
                header.Value = value;
            }

            IsChanged = true;
        }

        protected void AddOrUpdateCookie(string name, string value, string path, string domain)
        {
            MarketplaceConnectionCookieEntity? cookie = Connection
                    .Cookies
                    .FirstOrDefault(x => x.Name == name && x.Domain == domain);

            if (cookie is null)
            {
                cookie = new MarketplaceConnectionCookieEntity
                {
                    Domain = domain,
                    Name = name,
                    Path = path,
                    Value = value
                };
                Connection.Cookies.Add(cookie);
            }
            else
            {
                cookie.Value = value;
                cookie.Name = name;
                cookie.Path = path;
                cookie.Domain = domain;
            }

            IsChanged = true;
        }
    }
}
