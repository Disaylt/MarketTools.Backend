﻿using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Columns.Models;
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
    public class CommanHandler(IUnitOfWork _unitOfWork, 
        IAuthReadHelper _authReadHelper,
        IMapper _mapper) 
        : IRequestHandler<CreateCommand, ColumnVm>
    {
        private readonly IRepository<StandardAutoresponderColumn> _repository = _unitOfWork.GetRepository<StandardAutoresponderColumn>();

        public async Task<ColumnVm> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderColumn entity = Create(request.Name);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommintAsync();

            ColumnVm columnVm = _mapper.Map<ColumnVm>(entity);

            return columnVm;
        }

        private StandardAutoresponderColumn Create(string name)
        {
            return new StandardAutoresponderColumn
            {
                Name = name,
                UserId = _authReadHelper.UserId
            };
        }
    }
}
