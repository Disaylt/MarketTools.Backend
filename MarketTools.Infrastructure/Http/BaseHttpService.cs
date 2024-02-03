using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http
{
    internal abstract class BaseHttpService
    {
        protected async Task<T> GetViewResultAsJson<T>(HttpResponseMessage httpResponseMessage)
        {
            return await httpResponseMessage.Content
                .ReadFromJsonAsync<T>()
                ?? throw new AppBadRequestException("Не удалось преобразовать ответ http запроса.");
        }
    }
}
