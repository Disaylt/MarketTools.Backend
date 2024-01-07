using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.Commands.Delete
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<StandardAutoresponderBlackListEntity>>
    {
        private readonly IRepository<StandardAutoresponderBlackListEntity> _repository = _authUnitOfWork.StandardAutoresponderBlackLists;

        public async Task Handle(DefaultDeleteCommand<StandardAutoresponderBlackListEntity> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderBlackListEntity entity = await _repository.FirstAsync(x=> x.Id == request.Id);
            _repository.Remove(entity);

            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
