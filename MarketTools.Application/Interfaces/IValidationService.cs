using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces
{
    public interface IValidationService<TRequest>
    {
        public Task ThrowValidateError<TData>(TData value);
        public Task<bool> TryValidateAsync<TData>(TData value);
    }
}
