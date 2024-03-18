using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Common.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Proxy
{
    internal class OptionsProxyService(IOptions<SequreSettings> _options, IProxyConverter _proxyConverter)
        : IProxyService
    {
        private static Random _random = new Random();

        public IWebProxy GetRandom()
        {
            int count = CountProxies();
            int selectedIndex = _random.Next(count);
            string proxy = SelectProxy(selectedIndex);

            return _proxyConverter.Convert(proxy);
        }

        private string SelectProxy(int index)
        {
            return _options
                .Value
                .Proxies
                .ToArray()
                [index];
        }

        private int CountProxies()
        {
            return _options
                .Value
                .Proxies
                .Count();
        }
    }
}
