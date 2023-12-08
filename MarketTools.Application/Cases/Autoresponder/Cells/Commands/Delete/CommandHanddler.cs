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

namespace MarketTools.Application.Cases.Autoresponder.Cells.Commands.Delete
{
    public class CommandHanddler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<AutoresponderCell>>
    {
        public async Task Handle(DefaultDeleteCommand<AutoresponderCell> request, CancellationToken cancellationToken)
        {
            AutoresponderCell entity = await _authUnitOfWork.AutoresponderCells
                .FirstAsync(x => x.Id == request.Id);

            _authUnitOfWork.AutoresponderCells.Remove(entity);
            await _authUnitOfWork.CommintAsync();
        }
    }
}
