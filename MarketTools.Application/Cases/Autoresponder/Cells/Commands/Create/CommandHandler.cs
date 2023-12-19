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
        IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateCommand, CellVm>
    {
        private readonly IRepository<AutoresponderStandardCell> _repository = _unitOfWork.GetRepository<AutoresponderStandardCell>();

        public async Task<CellVm> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            AutoresponderStandardCell entity = Create(request);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommintAsync();

            return _mapper.Map<CellVm>(entity);
        }

        private AutoresponderStandardCell Create(CreateCommand request)
        {
            return new AutoresponderStandardCell
            {
                ColumnId = request.ColumnId,
                Value = request.Value
            };
        }
    }
}
