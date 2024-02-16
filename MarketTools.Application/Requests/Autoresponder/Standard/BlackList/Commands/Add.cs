using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Identity;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Limits;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.Commands
{
    public class BlackListAddCommand : IRequest<StandardAutoresponderBlackListEntity>
    {
        public required string Name { get; set; }
    }

    public class AddCommandValidator : AbstractValidator<BlackListAddCommand>
    {
        public AddCommandValidator(ILimitsService<IStandarAutoresponderLimits> limitsService, IAuthUnitOfWork authUnitOfWork)
        {
            RuleFor(x => x)
                .MustAsync(async (x, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalBlackLists = await authUnitOfWork.GetRepository<StandardAutoresponderBlackListEntity>()
                        .CountAsync(ct);

                    return totalBlackLists < limits.MaxBlackList;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит черных списков.");
        }
    }

    public class AddCommandHandler(IContextService<IdentityContext> _identityContext,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<BlackListAddCommand, StandardAutoresponderBlackListEntity>
    {

        private readonly IRepository<StandardAutoresponderBlackListEntity> _repsitory = _unitOfWork.GetRepository<StandardAutoresponderBlackListEntity>();

        public async Task<StandardAutoresponderBlackListEntity> Handle(BlackListAddCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderBlackListEntity entity = Create(request);
            await _repsitory.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return entity;
        }

        private StandardAutoresponderBlackListEntity Create(BlackListAddCommand request)
        {
            return new StandardAutoresponderBlackListEntity
            {
                UserId = _identityContext.Context.UserId,
                Name = request.Name
            };
        }
    }
}
