﻿using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Requests;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Columns.Commands.Delete
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GenericDeleteCommand<StandardAutoresponderColumnEntity>, Unit>
    {
        private readonly IRepository<StandardAutoresponderColumnEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderColumnEntity>();

        public async Task<Unit> Handle(GenericDeleteCommand<StandardAutoresponderColumnEntity> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderColumnEntity entity = await _repository.FirstAsync(x => x.Id == request.Id);

            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync();

            return Unit.Value;
        }
    }
}
