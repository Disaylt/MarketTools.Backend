using ClosedXML.Excel;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http.Wb;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Reqeusts.Wb
{
    internal class WbHttpRequestFactory<T>(IServiceProvider _serviceProvider, Dictionary<MarketplaceConnectionType, Func<IServiceProvider, T>> _serviceDictionary)
        : IWbHttpRequestFactory<T>
    {
        public T Create(MarketplaceConnectionType type)
        {
            var serviceCall = _serviceDictionary
                .GetValueOrDefault(type)
                ?? throw new AppNotFoundException("Http cервис не добавлен");

            return serviceCall.Invoke(_serviceProvider);
        }
    }
}
