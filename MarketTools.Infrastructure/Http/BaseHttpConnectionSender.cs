﻿using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http
{
    internal abstract class BaseHttpConnectionSender : IHttpConnectionClient
    {
        protected MarketplaceConnectionEntity Connection { get; }
        public HttpClient HttpClient { get; }

        public BaseHttpConnectionSender(IContextService<MarketplaceConnectionEntity> connectionContextReader, HttpClient httpClient)
        {
            Connection = connectionContextReader.Context;
            HttpClient = httpClient;
        }

        public virtual async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage);

            if ((int)httpResponseMessage.StatusCode >= 400)
            {
                throw new AppConnectionBadRequestException(Connection, httpResponseMessage.StatusCode);
            }

            return httpResponseMessage;
        }
    }
}