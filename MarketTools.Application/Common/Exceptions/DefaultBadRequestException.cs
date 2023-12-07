using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Exceptions
{
    public class DefaultBadRequestException : Exception
    {
        public DefaultBadRequestException() { }
        public DefaultBadRequestException(string message) : base(message) { }
    }
}
