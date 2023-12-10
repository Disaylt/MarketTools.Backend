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
        private readonly IRepository<AutoresponderCell> _repository = _unitOfWork.GetRepository<AutoresponderCell>();

        public async Task<CellVm> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            AutoresponderCell entity = Create(request);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommintAsync();

            return _mapper.Map<CellVm>(entity);
        }

        private AutoresponderCell Create(CreateCommand request)
        {
            return new AutoresponderCell
            {
                ColumnId = request.ColumnId,
                Value = request.Value
            };
        }
    }
}
