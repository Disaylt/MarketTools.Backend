using FluentValidation;
using MarketTools.Application.Interfaces;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Articles.Commands.EditRange
{
    public class CommandValidator : CommonValidator<ArticlesEditRangeCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService) : base(authUnitOfWork)
        {
            CanIntercatTemplate(RuleFor(x => x.TemplateId));

            RuleFor(x => x)
                .MustAsync(async (article, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalArticles = await authUnitOfWork.StandardAutoresponderTemplateArticles.CountAsync();
                    int totalArticlesForAdd = article.Articles.Count();

                    return totalArticles + totalArticlesForAdd < limits.MaxTemplateArticles;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит артикулов.");
        }
    }
}
