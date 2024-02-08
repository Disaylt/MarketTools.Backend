using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Services.Exceptions
{
    internal class HttpExceptionHandleService : IExceptionHandleService<AppConnectionBadRequestException>
    {
        public Task Hadnle(AppConnectionBadRequestException exeption)
        {
            throw new NotImplementedException();
        }
    }
}
