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
        IMainDatabaseContext _context,
        IAuthReadHelper _authReadHelper)
        : IRequestHandler<UpdateCellCommand, CellVm>
    {
        public async Task<CellVm> Handle(UpdateCellCommand request, CancellationToken cancellationToken)
        {
            AutoresponderCell entity = await _context.AutoresponderCells
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.Column.UserId == _authReadHelper.UserId)
                ?? throw new DefaultNotFoundException();

            entity.Value = request.Value;

            _context.AutoresponderCells.Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<CellVm>(entity);
        }
    }
}
