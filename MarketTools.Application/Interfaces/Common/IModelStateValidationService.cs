using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Common
{
    public interface IModelStateValidationService
    {
        public void ThrowValidateError<T>(T data);
        public bool IsValid<T>(T data, out List<ValidationResult> errors);
    }
}
