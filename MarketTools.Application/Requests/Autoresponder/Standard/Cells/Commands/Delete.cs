using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Requests;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Cells.Commands
{
    public class DeleteCommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GenericDeleteCommand<StandardAutoresponderCellEntity>, Unit>
    {
        private readonly IRepository<StandardAutoresponderCellEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderCellEntity>();

        public async Task<Unit> Handle(GenericDeleteCommand<StandardAutoresponderCellEntity> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderCellEntity entity = await _repository.FirstAsync(x => x.Id == request.Id);

            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync();

            return Unit.Value;
        }
    }
}
