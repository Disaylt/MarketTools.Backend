using MarketTools.Application.Common.Exceptions;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using MarketTools.Domain.Http.WB.Seller.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http
{
    internal class BaseHttpService
    {
        protected async Task<T> ReadAsJsonAsync<T>(HttpResponseMessage message)
        {
            return await message
                .Content
                .ReadFromJsonAsync<T>()
                ?? throw new AppNotFoundException("Не удалось преобразовать json wb api отзыовов.");
        }
    }
}
