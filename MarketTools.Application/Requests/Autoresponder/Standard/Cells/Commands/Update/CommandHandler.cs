using AutoMapper;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Cells.Commands.Update
{
    public class CommandHandler
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
