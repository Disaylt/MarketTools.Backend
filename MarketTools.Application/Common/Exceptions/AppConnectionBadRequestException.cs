using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
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
        public EnumProjectServices? Service { get; }

        public AppConnectionBadRequestException(MarketplaceConnectionEntity connection, HttpStatusCode statusCode, EnumProjectServices? enumProjectServices = null) 
            : base("Не удалось отправить запрос на сторонний сервер.") 
        {
            MarketplaceConnection = connection;
            HttpStatusCode = statusCode;
            Service = enumProjectServices;
        }
    }
}
