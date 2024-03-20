using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http
{
    public interface IHttpContentConverter<T>
    {
        public HttpContent Convert(T body);
    }
}
