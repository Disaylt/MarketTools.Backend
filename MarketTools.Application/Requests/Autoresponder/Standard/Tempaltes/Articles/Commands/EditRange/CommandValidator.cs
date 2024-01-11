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
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService)
        {
            CanIntercatTemplate(RuleFor(x => x.TemplateId), authUnitOfWork);
            MustMaxQuantityTemplateArticles(RuleFor(x => x.Articles), authUnitOfWork, limitsService);
        }
    }
}
