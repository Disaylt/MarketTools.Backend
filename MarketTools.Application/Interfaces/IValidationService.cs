using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces
{
    public interface IValidationService<TRequest, TData>
    {
        public Task ThrowValidateError(TData value);
        public Task<bool> TryValidateAsync(TData value);
    }
}
