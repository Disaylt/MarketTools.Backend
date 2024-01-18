using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketTools.Application.Interfaces;
using MarketTools.Domain.Interfaces.Limits;
using MarketTools.Application.Requests.Autoresponder.Standard;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.Add
{
    public class CommandValidator : CommonValidator<ArticleAddCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork,
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
}
