using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Columns.Commands.Delete
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<AutoresponderStandardColumn>>
    {
        private readonly IAuthRepository<AutoresponderStandardColumn> _repository = _authUnitOfWork.AutoresponderColumns;

        public async Task Handle(DefaultDeleteCommand<AutoresponderStandardColumn> request, CancellationToken cancellationToken)
        {
            AutoresponderStandardColumn entity = await _repository.FirstAsync(x=> x.Id == request.Id);

            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync();
        }
    }
}
