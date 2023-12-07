using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Exceptions
{
    public class DefaultNotFoundException : Exception
    {
        public DefaultNotFoundException() { }
        public DefaultNotFoundException(string message) : base(message) { }
    }
}
