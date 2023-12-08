using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Cells.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Cells.Commands.Create
{
    public class CommandHandler 
        (IMapper _mapper,
        IMainDatabaseContext _context)
        : IRequestHandler<CreateCellCommand, CellVm>
    {
        public async Task<CellVm> Handle(CreateCellCommand request, CancellationToken cancellationToken)
        {
            AutoresponderCell entity = Create(request);

            await _context.AutoresponderCells
                .AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<CellVm>(entity);
        }

        private AutoresponderCell Create(CreateCellCommand request)
        {
            return new AutoresponderCell
            {
                ColumnId = request.ColumnId,
                Value = request.Value
            };
        }
    }
}
