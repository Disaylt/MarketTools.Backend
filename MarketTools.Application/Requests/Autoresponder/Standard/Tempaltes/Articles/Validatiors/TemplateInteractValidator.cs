using FluentValidation;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Requests.Autoresponder.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Validatiors
{
    public class TemplateInteractValidator<T> : CommonValidator<T> where T : TemplateBasicCommand
    {
        public TemplateInteractValidator(IAuthUnitOfWork authUnitOfWork) : base(authUnitOfWork)
        {
            CanIntercatTemplate(RuleFor(x => x.TemplateId));
            RuleFor(x => x.TemplateId)
                .MustAsync(async (templateId, ct) =>
                {
                    return await authUnitOfWork.StandardAutoresponderTemplates.AnyAsync(x => x.Id == templateId);
                })
                .WithErrorCode("404")
                .WithMessage("Шаблон не найден.");
        }
    }
}
