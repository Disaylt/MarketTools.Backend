using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard
{
    public abstract class CommonValidator<T> : AbstractValidator<T>
    {
        private readonly IAuthUnitOfWork _authUnitOfWork;

        public CommonValidator(IAuthUnitOfWork authUnitOfWork) 
        {
            _authUnitOfWork = authUnitOfWork;
        }

        protected IRuleBuilderOptions<T, int> CanIntercatTemplate(IRuleBuilderInitial<T, int> ruleBuilderInitial)
        {
            return ruleBuilderInitial
                .MustAsync(async (templateId, ct) =>
                {
                    return await _authUnitOfWork.StandardAutoresponderTemplates.AnyAsync(x => x.Id == templateId);
                })
                .WithErrorCode("404")
                .WithMessage("Шаблон не найден.");
        }
    }
}
