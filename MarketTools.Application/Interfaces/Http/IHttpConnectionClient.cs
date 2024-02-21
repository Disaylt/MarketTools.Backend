using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http
{
    public interface IHttpConnectionClient
    {
        public HttpClient HttpClient { get; }
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);
    }
}
