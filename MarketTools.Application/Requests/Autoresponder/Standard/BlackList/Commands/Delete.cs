using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Requests;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.Commands
{
    public class DeleteCommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GenericDeleteCommand<StandardAutoresponderBlackListEntity>, Unit>
    {
        private readonly IRepository<StandardAutoresponderBlackListEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderBlackListEntity>();

        public async Task<Unit> Handle(GenericDeleteCommand<StandardAutoresponderBlackListEntity> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderBlackListEntity entity = await _repository
                .GetAsQueryable()
                .Include(x => x.Templates)
                .FirstAsync(x => x.Id == request.Id);
            entity.Templates.Clear();

            _repository.Remove(entity);

            await _authUnitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
