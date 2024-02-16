using AutoMapper;
using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Models.Identity;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Interfaces.Limits;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands
{
    public class RecommendationProductCreateCommand : IRequest<StandardAutoresponderRecommendationProductEntity>, IHasMap
    {
        public required string FeedbackArticle { get; set; }
        public string? FeedbackProductName { get; set; }
        public string? RecommendationArticle { get; set; }
        public string? RecommendationProductName { get; set; }
        public MarketplaceName MarketplaceName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RecommendationProductCreateCommand, StandardAutoresponderRecommendationProductEntity>();
        }
    }

    public class CreateCommandValidator : AbstractValidator<RecommendationProductCreateCommand>
    {
        public CreateCommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService)
        {
            IRepository<StandardAutoresponderRecommendationProductEntity> repository = authUnitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();
            RuleFor(x => x)
                .MustAsync(async (recommendationProduct, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalRecommendationProducts = await repository.CountAsync();

                    return totalRecommendationProducts < limits.MaxRecommendationProducts;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит товаров для рекомендации.");
        }
    }

    public class CreateCommandHandler
        (IMapper _mapper,
        IUnitOfWork _unitOfWork,
        IContextService<IdentityContext> _identityContext)
        : IRequestHandler<RecommendationProductCreateCommand, StandardAutoresponderRecommendationProductEntity>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();

        public async Task<StandardAutoresponderRecommendationProductEntity> Handle(RecommendationProductCreateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderRecommendationProductEntity entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return entity;
        }

        private StandardAutoresponderRecommendationProductEntity Build(RecommendationProductCreateCommand request)
        {
            StandardAutoresponderRecommendationProductEntity entity = _mapper.Map<StandardAutoresponderRecommendationProductEntity>(request);
            entity.UserId = _identityContext.Context.UserId;

            return entity;
        }
    }
}
