using MarketTools.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces
{
    public interface ILimitsService<T> where T : ILimitModel
    {
        public Task<T> GetAsync();
    }
}
