using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.BanWords.Commands.Delete
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<StandardAutoresponderBanWordEntity>>
    {
        private readonly IRepository<StandardAutoresponderBanWordEntity> _repository = _authUnitOfWork.StandardAutoresponderBanWords;

        public async Task Handle(DefaultDeleteCommand<StandardAutoresponderBanWordEntity> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderBanWordEntity entity = await _repository.FirstAsync(x=> x.Id == request.Id, cancellationToken);
            _repository.Remove(entity);

            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
