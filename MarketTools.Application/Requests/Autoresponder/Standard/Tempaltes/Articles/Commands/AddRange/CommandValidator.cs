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
        {
            CanIntercatTemplate(RuleFor(x => x.TemplateId), authUnitOfWork);
            MustMaxQuantityTemplateArticlesAtOnce(RuleFor(x => x.Articles));
            MustMaxQuantityTemplateArticles(RuleFor(x=> x.Articles), authUnitOfWork, limitsService);
        }
    }
}
