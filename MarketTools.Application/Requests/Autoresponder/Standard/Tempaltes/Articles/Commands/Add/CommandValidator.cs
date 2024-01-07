using FluentValidation;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Validatiors;
using MarketTools.Application.Interfaces.Autoresponder.Standard.Models;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketTools.Application.Interfaces;
using MarketTools.Domain.Interfaces.Limits;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.Add
{
    public class CommandValidator : TemplateInteractValidator<ArticleAddCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork,
            ILimitsService<IStandarAutoresponderLimits> limitsService,
            IUnitOfWork unitOfWork) 
            : base(authUnitOfWork)
        {
            IRepository<StandardAutoresponderTemplateArticleEntity> repository = unitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();

            RuleFor(x => x)
                .MustAsync(async (value, ct) =>
                {
                    bool isExists = await repository.AnyAsync(entity =>
                        entity.Article == value.Article && entity.TemplateId == value.TemplateId);
                    return !isExists;
                })
                .WithMessage("Такой арткул уже добавлен.");

            RuleFor(x => x)
                .MustAsync(async (article, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalArticles = await authUnitOfWork.StandardAutoresponderTemplateArticles.CountAsync();

                    return totalArticles < limits.MaxTemplateArticles;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит шаблонов.");

        }
    }
}
