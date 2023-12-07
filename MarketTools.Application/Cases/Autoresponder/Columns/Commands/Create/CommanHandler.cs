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

namespace MarketTools.Application.Cases.Autoresponder.Columns.Commands.Create
{
    public class CommanHandler(IMainDatabaseContext _context, 
        IAuthReadHelper _authReadHelper,
        IMapper _mapper) 
        : IRequestHandler<ColumnCreateCommand, ColumnVm>
    {
        public async Task<ColumnVm> Handle(ColumnCreateCommand request, CancellationToken cancellationToken)
        {
            AutoresponderColumn entity = Create(request.Name);

            await _context.AutoresponderColumns.AddAsync(entity);
            await _context.SaveChangesAsync();

            ColumnVm columnVm = _mapper.Map<ColumnVm>(entity);

            return columnVm;
        }

        private AutoresponderColumn Create(string name)
        {
            return new AutoresponderColumn
            {
                Name = name,
                UserId = _authReadHelper.UserId
            };
        }
    }
}
