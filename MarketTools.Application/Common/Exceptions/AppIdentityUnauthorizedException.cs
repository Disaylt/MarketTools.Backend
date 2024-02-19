using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Exceptions
{
    public class AppIdentityUnauthorizedException : Exception
    {
        public AppIdentityUnauthorizedException() : base("Пользователь не авторизован.") { }
        public AppIdentityUnauthorizedException(string message) : base(message) { }
    }
}
