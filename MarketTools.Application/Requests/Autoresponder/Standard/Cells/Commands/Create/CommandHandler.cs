using AutoMapper;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Cells.Commands.Create
{
    public class CommandHandler(IUnitOfWork _unitOfWork)
        : IRequestHandler<CellCreateCommand, StandardAutoresponderCellEntity>
    {
        private readonly IRepository<StandardAutoresponderCellEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderCellEntity>();

        public async Task<StandardAutoresponderCellEntity> Handle(CellCreateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderCellEntity entity = Create(request);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommintAsync();

            return entity;
        }

        private StandardAutoresponderCellEntity Create(CellCreateCommand request)
        {
            return new StandardAutoresponderCellEntity
            {
                ColumnId = request.ColumnId,
                Value = request.Value
            };
        }
    }
}
