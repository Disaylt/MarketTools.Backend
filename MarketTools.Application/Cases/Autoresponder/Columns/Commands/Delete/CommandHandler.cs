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
        : IRequestHandler<DefaultDeleteCommand<AutoresponderColumn>>
    {
        public async Task Handle(DefaultDeleteCommand<AutoresponderColumn> request, CancellationToken cancellationToken)
        {
            AutoresponderColumn entity = await _authUnitOfWork.AutoresponderColumns
                .FirstAsync(x=> x.Id == request.Id);

            _authUnitOfWork.AutoresponderColumns.Remove(entity);
            await _authUnitOfWork.CommintAsync();
        }
    }
}
