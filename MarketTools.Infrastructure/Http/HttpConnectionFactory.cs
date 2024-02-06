using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http
{
    internal class HttpConnectionFactory<T>(IHttpConnectionContextWriter _httpConnectionContextWriter, IServiceProvider _serviceProvider)
        : IHttpConnectionFactory<T> where T : class
    {
        public T Create(MarketplaceConnectionEntity connection)
        {
            _httpConnectionContextWriter.Write(connection);

            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
