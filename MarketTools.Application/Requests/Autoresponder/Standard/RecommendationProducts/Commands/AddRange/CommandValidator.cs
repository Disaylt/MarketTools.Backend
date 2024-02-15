using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketTools.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using MarketTools.Application.Interfaces.Common;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands.AddRange
{
    public class CommandValidator : AbstractValidator<RecommendationProductAddRangeCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService, IModelStateValidationService modelStateValidationService)
        {
            RuleFor(command => command.Products)
                .MustAsync(async (newProducts, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalRecommendationProducts = await authUnitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>()
                        .CountAsync();

                    return totalRecommendationProducts + newProducts.Count() < limits.MaxRecommendationProducts;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит товаров для рекомендации.");

            RuleForEach(command => command.Products)
                .Custom((product, context) =>
                {
                    if(modelStateValidationService.IsValid(product, out List<ValidationResult> errors) == false)
                    {
                        string errorMessage = errors.FirstOrDefault()?.ErrorMessage ?? "Не прошел валидацию";
                        context.AddFailure($"{product.FeedbackArticle} - {errorMessage}");
                    }
                });
        }
    }
}
