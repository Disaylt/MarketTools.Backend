using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces
{
    public interface IExceptionHandleService<T> where T : Exception
    {
        public Task Hadnle(T exeption);
    }
}
