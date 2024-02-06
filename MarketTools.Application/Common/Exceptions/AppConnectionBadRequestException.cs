using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Exceptions
{
    public class AppConnectionBadRequestException : Exception
    {
        public MarketplaceConnectionEntity MarketplaceConnection { get; }
        public HttpStatusCode HttpStatusCode { get; }

        public AppConnectionBadRequestException(MarketplaceConnectionEntity connection, HttpStatusCode statusCode) 
            : base("Не удалось отправить запрос на сторонний сервер.") 
        {
            MarketplaceConnection = connection;
            HttpStatusCode = statusCode;
        }
    }
}
