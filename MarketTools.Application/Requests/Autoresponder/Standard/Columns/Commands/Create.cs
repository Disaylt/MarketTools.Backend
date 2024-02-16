using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Identity;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Interfaces.Limits;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Columns.Commands
{
    public class ColumnCreateCommand : IRequest<StandardAutoresponderColumnEntity>
    {
        public string Name { get; set; } = null!;
        public AutoresponderColumnType Type { get; set; }
    }

    public class CreateCommandValidator : AbstractValidator<ColumnCreateCommand>
    {
        public CreateCommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService)
        {
            IRepository<StandardAutoresponderColumnEntity> repository = authUnitOfWork.GetRepository<StandardAutoresponderColumnEntity>();
            RuleFor(x => x)
                .MustAsync(async (columnId, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalColumns = await repository.CountAsync();

                    return totalColumns < limits.MaxColumns;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит колонок.");
        }
    }

    public class CreateCommanHandler(IUnitOfWork _unitOfWork,
        IContextService<IdentityContext> _identityContext)
        : IRequestHandler<ColumnCreateCommand, StandardAutoresponderColumnEntity>
    {
        private readonly IRepository<StandardAutoresponderColumnEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderColumnEntity>();

        public async Task<StandardAutoresponderColumnEntity> Handle(ColumnCreateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderColumnEntity entity = Create(request);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        private StandardAutoresponderColumnEntity Create(ColumnCreateCommand request)
        {
            return new StandardAutoresponderColumnEntity
            {
                Name = request.Name,
                Type = request.Type,
                UserId = _identityContext.Context.UserId,
            };
        }
    }
}
