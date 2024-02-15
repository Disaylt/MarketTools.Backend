using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard
{
    public abstract class CommonValidator<T> : AbstractValidator<T>
    {

        protected IRuleBuilderOptions<T, int> CanIntercatTemplate(IRuleBuilderInitial<T, int> ruleBuilderInitial, IAuthUnitOfWork authUnitOfWork)
        {
            IRepository<StandardAutoresponderTemplateEntity> repository = authUnitOfWork.GetRepository<StandardAutoresponderTemplateEntity>();

            return ruleBuilderInitial
                .MustAsync(async (templateId, ct) =>
                {
                    return await repository.AnyAsync(x => x.Id == templateId);
                })
                .WithErrorCode("404")
                .WithMessage("Шаблон не найден.");
        }

        protected IRuleBuilderOptions<T, IEnumerable<string>> MustMaxQuantityTemplateArticlesAtOnce(IRuleBuilderInitial<T, IEnumerable<string>> ruleBuilderInitial)
        {
            return ruleBuilderInitial
            .Must(x => x.Count() > 1500)
                .WithErrorCode("400")
                .WithMessage("Невозможно добавить более 1500 артикулов за 1 раз.");
        }

        protected IRuleBuilderOptions<T, IEnumerable<string>> MustMaxQuantityTemplateArticles(
            IRuleBuilderInitial<T, IEnumerable<string>> ruleBuilderInitial, 
            IAuthUnitOfWork authUnitOfWork,
            ILimitsService<IStandarAutoresponderLimits> limitsService)
        {
            IRepository<StandardAutoresponderTemplateArticleEntity> repository = authUnitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();

            return ruleBuilderInitial
            .MustAsync(async (articles, ct) =>
            {
                IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                int totalArticles = await repository.CountAsync();
                int totalArticlesForAdd = articles.Count();

                return totalArticles + totalArticlesForAdd < limits.MaxTemplateArticles;
            })
            .WithErrorCode("400")
            .WithMessage("Превышен лимит артикулов.");
        }
    }
}
