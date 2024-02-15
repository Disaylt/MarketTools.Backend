using FluentValidation;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Models;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Limits;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Articles.Commands
{
    public class ArticleAddCommand : TemplateBasicCommand, IRequest<StandardAutoresponderTemplateArticleEntity>
    {
        public required string Value { get; set; }
    }

    public class AddCommandValidator : CommonValidator<ArticleAddCommand>
    {
        public AddCommandValidator(IAuthUnitOfWork authUnitOfWork,
            ILimitsService<IStandarAutoresponderLimits> limitsService,
            IUnitOfWork unitOfWork)
        {
            IRepository<StandardAutoresponderTemplateArticleEntity> repository = unitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();

            CanIntercatTemplate(RuleFor(x => x.TemplateId), authUnitOfWork);

            RuleFor(x => x)
                .MustAsync(async (article, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalArticles = await repository.CountAsync();

                    return totalArticles < limits.MaxTemplateArticles;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит артикулов.");

        }
    }

    public class AddCommandHandler
        (IUnitOfWork _unitOfWork)
        : IRequestHandler<ArticleAddCommand, StandardAutoresponderTemplateArticleEntity>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticleEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();

        public async Task<StandardAutoresponderTemplateArticleEntity> Handle(ArticleAddCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateArticleEntity entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return entity;
        }

        private StandardAutoresponderTemplateArticleEntity Build(ArticleAddCommand request)
        {
            return new StandardAutoresponderTemplateArticleEntity
            {
                Value = request.Value,
                TemplateId = request.TemplateId
            };
        }
    }
}
