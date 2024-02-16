using FluentValidation;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Identity;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Models;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Utilities;
using MarketTools.Application.Services;
using MarketTools.Application.Utilities;
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
        public AddRangeCommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService)
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
        }
    }

    public class AddRangeCommandHandler(IContextService<IdentityContext> _identityContext,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<RecommendationProductAddRangeCommand, IEnumerable<StandardAutoresponderRecommendationProductEntity>>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();

        public async Task<IEnumerable<StandardAutoresponderRecommendationProductEntity>> Handle(RecommendationProductAddRangeCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderRecommendationProductEntity> products = new DetailsBuilder(request)
                .AddMainDetails(_identityContext.Context.UserId, request.MarketplaceName)
                .Build();

            ValidateProductsDetails(products);

            await _repository.AddRangeAsync(products);
            await _unitOfWork.CommitAsync(cancellationToken);

            return products;
        }

        private void ValidateProductsDetails(IEnumerable<StandardAutoresponderRecommendationProductEntity> products)
        {
            foreach (var product in products)
            {
                ModelStateValidationUtility.ThrowValidateError(product);
            }
        }
    }
}
