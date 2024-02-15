using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.BanWords.Commands
{
    public class BanWordAddCommand : IRequest<StandardAutoresponderBanWordEntity>
    {
        public required string Value { get; set; }
        public int BlackListId { get; set; }
    }

    public class AddCommandValidator : AbstractValidator<BanWordAddCommand>
    {
        public AddCommandValidator(IAuthUnitOfWork authUnitOfWork)
        {
            RuleFor(x => x.BlackListId)
                .MustAsync(async (blackListId, ct) =>
                {
                    StandardAutoresponderBlackListEntity? entity = await authUnitOfWork.GetRepository<StandardAutoresponderBlackListEntity>()
                        .FirstOrDefaultAsync(x => x.Id == blackListId);

                    return entity != null;
                })
                .WithErrorCode("404")
                .WithMessage("Черынй список не найден.");
        }
    }

    public class AddCommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<BanWordAddCommand, StandardAutoresponderBanWordEntity>
    {
        private readonly IRepository<StandardAutoresponderBanWordEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderBanWordEntity>();

        public async Task<StandardAutoresponderBanWordEntity> Handle(BanWordAddCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderBanWordEntity entity = Create(request);

            await _repository.AddAsync(entity, cancellationToken);
            await _authUnitOfWork.CommintAsync(cancellationToken);

            return entity;
        }

        private StandardAutoresponderBanWordEntity Create(BanWordAddCommand request)
        {
            return new StandardAutoresponderBanWordEntity
            {
                Value = request.Value,
                BlackListId = request.BlackListId
            };
        }
    }
}
