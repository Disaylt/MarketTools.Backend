using MarketTools.Application.Interfaces.Http.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Clients
{
    internal class RandomProxyClient : BaseHttpClient, IRandomProxyClient
    {
        public RandomProxyClient(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
