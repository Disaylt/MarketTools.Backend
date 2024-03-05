using MarketTools.Domain.Entities;
using MarketTools.Infrastructure.MarketplaceConnections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Builders
{
    internal abstract class AbstractConnectionBuilder
    {
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();
        private readonly List<CookieModel> _cookies = new List<CookieModel>();
        public MarketplaceConnectionEntity Build(MarketplaceConnectionEntity connection)
        {
            SetCookies(connection);
            SetHeaders(connection);

            return connection;
        }

        public void AddOrUpdateCookie(CookieModel newCookie)
        {
            CookieModel? cookie = _cookies
                .FirstOrDefault(x=> x.Name == newCookie.Name && x.Domain == newCookie.Domain);

            if (cookie is null)
            {
                cookie = new CookieModel
                {
                    Domain = newCookie.Domain,
                    Name = newCookie.Name,
                    Path = newCookie.Path,
                    Value = newCookie.Value
                };
                _cookies.Add(cookie);
            }
            else
            {
                cookie.Value = newCookie.Value;
            }
        }

        public void AddOrUpdateHeader(string name, string value)
        {
            if(_headers.ContainsKey(name))
            {
                _headers[name] = value;
            }
            else
            {
                _headers.Add(name, value);
            }
        }

        private void SetHeaders(MarketplaceConnectionEntity connection)
        {
            foreach(var newHeader in _headers)
            {
                MarketplaceConnectionHeaderEntity? header = connection
                    .Headers
                    .FirstOrDefault(x => x.Name == newHeader.Key);

                if(header is null)
                {
                    header = new MarketplaceConnectionHeaderEntity
                    {
                        Name = newHeader.Key,
                        Value = newHeader.Value
                    };
                    connection.Headers.Add(header);
                }
                else
                {
                    header.Value = newHeader.Value;
                }
            }
        }

        private void SetCookies(MarketplaceConnectionEntity connection)
        {
            foreach(var newCookie in _cookies)
            {
                MarketplaceConnectionCookieEntity? cookie = connection
                    .Cookies
                    .FirstOrDefault(x => x.Name == newCookie.Name && x.Domain == newCookie.Domain);

                if(cookie is null)
                {
                    cookie = new MarketplaceConnectionCookieEntity
                    {
                        Domain = newCookie.Domain,
                        Name = newCookie.Name,
                        Path = newCookie.Path,
                        Value = newCookie.Value
                    };
                    connection.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Value = newCookie.Value;
                    cookie.Name = newCookie.Name;
                    cookie.Path = newCookie.Path;
                    cookie.Domain = newCookie.Domain;
                }
            }
        }
    }
}
