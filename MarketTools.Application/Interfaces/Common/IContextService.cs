using MarketTools.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Common
{
    public interface IContextService<T> where T : IContext
    {
        public T Context { get; set; }
    }
}
