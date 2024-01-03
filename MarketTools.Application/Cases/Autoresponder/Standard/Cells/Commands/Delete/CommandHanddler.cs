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

namespace MarketTools.Application.Cases.Autoresponder.Standard.Cells.Commands.Delete
{
    public class CommandHanddler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<StandardAutoresponderCell>>
    {
        private readonly IRepository<StandardAutoresponderCell> _repository = _authUnitOfWork.StandardAutoresponderCells;

        public async Task Handle(DefaultDeleteCommand<StandardAutoresponderCell> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderCell entity = await _repository.FirstAsync(x => x.Id == request.Id);

            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync();
        }
    }
}
