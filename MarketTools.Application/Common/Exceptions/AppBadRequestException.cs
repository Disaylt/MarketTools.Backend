using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Exceptions
{
    public class AppBadRequestException : Exception
    {
        public AppBadRequestException() : base("Не удалось обработать ваш запрос.") { }
        public AppBadRequestException(string message) : base(message) { }
    }
}
