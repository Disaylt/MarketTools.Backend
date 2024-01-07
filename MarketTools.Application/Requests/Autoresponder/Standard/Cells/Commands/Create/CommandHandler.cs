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
        : IRequestHandler<CellCreateCommand, StandardAutoresponderCell>
    {
        private readonly IRepository<StandardAutoresponderCell> _repository = _unitOfWork.GetRepository<StandardAutoresponderCell>();

        public async Task<StandardAutoresponderCell> Handle(CellCreateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderCell entity = Create(request);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommintAsync();

            return entity;
        }

        private StandardAutoresponderCell Create(CellCreateCommand request)
        {
            return new StandardAutoresponderCell
            {
                ColumnId = request.ColumnId,
                Value = request.Value
            };
        }
    }
}
