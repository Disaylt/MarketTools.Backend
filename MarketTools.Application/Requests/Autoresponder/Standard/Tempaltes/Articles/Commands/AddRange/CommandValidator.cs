using FluentValidation;
using MarketTools.Application.Interfaces.Autoresponder.Standard.Models;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketTools.Application.Interfaces;
using MarketTools.Domain.Interfaces.Limits;
using MarketTools.Application.Requests.Autoresponder.Standard;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.AddRange
{
    public class CommandValidator : CommonValidator<ArticleAddRangeCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork,
            ILimitsService<IStandarAutoresponderLimits> limitsService) 
            : base(authUnitOfWork)
        {
            CanIntercatTemplate(RuleFor(x => x.TemplateId));

            RuleFor(x => x.Articles)
                .Must(x => x.Count() > 1500)
                .WithErrorCode("400")
                .WithMessage("Невозможно добавить более 1500 артикулов за 1 раз.");

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
