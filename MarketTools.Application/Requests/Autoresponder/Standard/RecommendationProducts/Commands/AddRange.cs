using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Models;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Utilities;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Limits;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands
{
    public class RecommendationProductAddRangeCommand : RangeCommand, IRequest<IEnumerable<StandardAutoresponderRecommendationProductEntity>>
    {
    }

    public class AddRangeCommandValidator : AbstractValidator<RecommendationProductAddRangeCommand>
    {
        public AddRangeCommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService, IModelStateValidationService modelStateValidationService)
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
                    if (modelStateValidationService.IsValid(product, out List<ValidationResult> errors) == false)
                    {
                        string errorMessage = errors.FirstOrDefault()?.ErrorMessage ?? "Не прошел валидацию";
                        context.AddFailure($"{product.FeedbackArticle} - {errorMessage}");
                    }
                });
        }
    }

    public class AddRangeCommandHandler(IAuthReadHelper _authReadHelper,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<RecommendationProductAddRangeCommand, IEnumerable<StandardAutoresponderRecommendationProductEntity>>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();

        public async Task<IEnumerable<StandardAutoresponderRecommendationProductEntity>> Handle(RecommendationProductAddRangeCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderRecommendationProductEntity> products = new DetailsBuilder(request)
                .AddMainDetails(_authReadHelper.UserId)
                .Build();

            await _repository.AddRangeAsync(products);
            await _unitOfWork.CommintAsync(cancellationToken);

            return products;
        }
    }
}
