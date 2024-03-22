﻿using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
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
    internal class BaseConnectionConverter : IBaseConnectionConverter
    {
        public bool IsChanged { get; protected set; }

        protected MarketplaceConnectionEntity Connection { get; }

        public BaseConnectionConverter(MarketplaceConnectionEntity connection)
        {
            Connection = connection;
        }

        protected string? GetFromHeaders(string key)
        {
            return Connection
                .Headers
                .FirstOrDefault(x => x.Name == key)?
                .Value;
        }

        protected string? GetFromCookies(string name, string domain)
        {
            return Connection
                .Cookies
                .FirstOrDefault(x => x.Name == name && x.Domain == domain)?
                .Value;
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
