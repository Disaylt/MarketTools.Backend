using ClosedXML.Excel;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http
{
    internal class HttpResponseConverterFactory<THttpService, TResult>(IServiceProvider _serviceProvider,
        Dictionary<Type,Dictionary<MarketplaceConnectionType, Func<IServiceProvider, IHttpResponseConverter<TResult>>>> _converters)
        : IHttpResponseConverterFactory<THttpService, TResult>
    {
        public IHttpResponseConverter<TResult> Create(MarketplaceConnectionType type)
        {
            Func<IServiceProvider, IHttpResponseConverter<TResult>> converterCall = _converters
                .GetValueOrDefault(typeof(THttpService))?
                .GetValueOrDefault(type)
                ?? throw new AppNotFoundException("Не найден конвертер http овтета.");

            return converterCall.Invoke(_serviceProvider);
        }
    }
}
