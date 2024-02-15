using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Cells.Commands
{
    public class CellUpdateCommand : IRequest<StandardAutoresponderCellEntity>
    {
        public int Id { get; set; }
        public required string Value { get; set; }
    }

    public class UpdateCommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<CellUpdateCommand, StandardAutoresponderCellEntity>
    {
        private readonly IRepository<StandardAutoresponderCellEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderCellEntity>();
        public async Task<StandardAutoresponderCellEntity> Handle(CellUpdateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderCellEntity entity = await _repository.FirstAsync(x => x.Id == request.Id);

            entity.Value = request.Value;

            _repository.Update(entity);
            await _authUnitOfWork.CommintAsync();

            return entity;
        }
    }
}
