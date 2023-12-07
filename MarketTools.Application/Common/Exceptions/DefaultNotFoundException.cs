using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Exceptions
{
    public class DefaultNotFoundException : Exception
    {
        public DefaultNotFoundException() : base("Объект не найден.") { }
        public DefaultNotFoundException(string message) : base(message) { }
    }
}
