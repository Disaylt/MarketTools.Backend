using MarketTools.Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities
{
    internal class ModelStateValidationUtility
    {
        public static bool IsValid<T>(T data, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();

            if (data == null)
            {
                errors.Add(new ValidationResult("Модель не инициализрвоанна."));
                return false;
            }

            ValidationContext context = new ValidationContext(data, null, null);

            return Validator.TryValidateObject(data, context, errors, true);
        }

        public static void ThrowValidateError<T>(T data)
        {
            if (IsValid(data, out List<ValidationResult> errors) == false)
            {
                ValidationResult validationResult = errors.FirstOrDefault()
                    ?? new ValidationResult("Неизвестная ошибка.");
                throw new ValidationException(validationResult.ErrorMessage);
            }
        }
    }
}
