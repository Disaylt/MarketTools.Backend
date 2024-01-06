﻿using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Cells.Models;
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
    public class CommandHandler
        (IMapper _mapper,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateCommand, CellVm>
    {
        private readonly IRepository<StandardAutoresponderCell> _repository = _unitOfWork.GetRepository<StandardAutoresponderCell>();

        public async Task<CellVm> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderCell entity = Create(request);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommintAsync();

            return _mapper.Map<CellVm>(entity);
        }

        private StandardAutoresponderCell Create(CreateCommand request)
        {
            return new StandardAutoresponderCell
            {
                ColumnId = request.ColumnId,
                Value = request.Value
            };
        }
    }
}