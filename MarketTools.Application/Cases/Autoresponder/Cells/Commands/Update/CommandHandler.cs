using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Cells.Models;
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

namespace MarketTools.Application.Cases.Autoresponder.Cells.Commands.Update
{
    public class CommandHandler
        (IMapper _mapper,
        IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<UpdateCommand, CellVm>
    {
        public async Task<CellVm> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            AutoresponderCell entity = await _authUnitOfWork.AutoresponderCells
                .FirstAsync(x => x.Id == request.Id);

            entity.Value = request.Value;

            _authUnitOfWork.AutoresponderCells.Update(entity);
            await _authUnitOfWork.CommintAsync();

            return _mapper.Map<CellVm>(entity);
        }
    }
}
