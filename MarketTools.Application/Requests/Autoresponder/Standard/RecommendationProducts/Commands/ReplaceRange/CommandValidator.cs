using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces;
using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketTools.Application.Services;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands.ReplaceRange
{
    public class CommandValidator : AbstractValidator<RecommendationProductReplaceRangeCommand>
    {
        public CommandValidator(ILimitsService<IStandarAutoresponderLimits> limitsService, IModelStateValidationService modelStateValidationService)
        {
            RuleFor(command => command.Products)
                .MustAsync(async (newProducts, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();

                    return newProducts.Count() < limits.MaxRecommendationProducts;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит товаров для рекомендации.");

            RuleForEach(command => command.Products)
               .Custom((product, context) =>
               {
                   if (modelStateValidationService.IsValid(product, out List<ValidationResult> errors) == false)
                   {
                       string errorMessage = errors.FirstOrDefault()?.ErrorMessage ?? "Не прошел валидацию";
                       context.AddFailure($"{product.FeedbackArticle} - {errorMessage}");
                   }
               });
        }
    }
}
