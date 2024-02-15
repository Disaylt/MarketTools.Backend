using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Limits;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Commands
{
    public class TemplateAddCommand : IRequest<StandardAutoresponderTemplateEntity>
    {
        public required string Name { get; set; }
    }

    public class AddCommandValidator : AbstractValidator<TemplateAddCommand>
    {
        public AddCommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService)
        {
            IRepository<StandardAutoresponderTemplateEntity> repository = authUnitOfWork.GetRepository<StandardAutoresponderTemplateEntity>();

            RuleFor(x => x)
                .MustAsync(async (template, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalTemplates = await repository.CountAsync();

                    return totalTemplates < limits.MaxTemplates;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит шаблонов.");
        }
    }

    public class AddCommandHandler
        (IUnitOfWork _unitOfWork,
        IAuthReadHelper _authReadHelper)
        : IRequestHandler<TemplateAddCommand, StandardAutoresponderTemplateEntity>
    {
        private readonly IRepository<StandardAutoresponderTemplateEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplateEntity>();

        public async Task<StandardAutoresponderTemplateEntity> Handle(TemplateAddCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateEntity entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync();

            return entity;
        }

        private StandardAutoresponderTemplateEntity Build(TemplateAddCommand request)
        {
            return new StandardAutoresponderTemplateEntity
            {
                Name = request.Name,
                UserId = _authReadHelper.UserId
            };
        }
    }
}
