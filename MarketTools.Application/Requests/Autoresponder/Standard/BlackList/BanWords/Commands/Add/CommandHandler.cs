using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.BanWords.Commands.Add
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
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
