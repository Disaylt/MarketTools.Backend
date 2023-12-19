using FluentValidation;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Models;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Validations
{
    public class TemplateInteractValidator<T> : AbstractValidator<T> where T : TemplateBasicCommand
    {
        public TemplateInteractValidator(IAuthUnitOfWork authUnitOfWork)
        {
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
