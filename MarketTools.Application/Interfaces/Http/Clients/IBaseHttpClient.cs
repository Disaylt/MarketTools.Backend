﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http.Clients
{
    public interface IBaseHttpClient
    {
        public void SetBaseUrl(string value);
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);
    }
}