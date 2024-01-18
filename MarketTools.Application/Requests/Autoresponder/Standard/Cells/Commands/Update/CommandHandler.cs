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
        : IRequestHandler<CellUpdateCommand, StandardAutoresponderCell>
    {
        private readonly IRepository<StandardAutoresponderCell> _repository = _authUnitOfWork.StandardAutoresponderCells;
        public async Task<StandardAutoresponderCell> Handle(CellUpdateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderCell entity = await _repository.FirstAsync(x => x.Id == request.Id);

            entity.Value = request.Value;

            _repository.Update(entity);
            await _authUnitOfWork.CommintAsync();

            return entity;
        }
    }
}
