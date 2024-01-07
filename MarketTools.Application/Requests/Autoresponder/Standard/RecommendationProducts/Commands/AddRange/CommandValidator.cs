using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces;
using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands.AddRange
{
    public class CommandValidator : AbstractValidator<AddRangeCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService)
        {
            RuleFor(command => command.Products)
                .MustAsync(async (newProducts, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalRecommendationProducts = await authUnitOfWork.StandardAutoresponderRecommendationProducts.CountAsync();

                    return totalRecommendationProducts + newProducts.Count() < limits.MaxRecommendationProducts;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит шаблонов.");
        }
    }
}
