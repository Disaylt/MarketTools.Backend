using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Exceptions
{
    public class AppNotFoundException : Exception
    {
        public AppNotFoundException() : base("Объект не найден.") { }
        public AppNotFoundException(string message) : base(message) { }
    }
}
