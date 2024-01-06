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

namespace MarketTools.Application.Cases.Autoresponder.Standard.Columns.Commands.Delete
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<StandardAutoresponderColumnEntity>>
    {
        private readonly IRepository<StandardAutoresponderColumnEntity> _repository = _authUnitOfWork.StandardAutoresponderColumns;

        public async Task Handle(DefaultDeleteCommand<StandardAutoresponderColumnEntity> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderColumnEntity entity = await _repository.FirstAsync(x => x.Id == request.Id);

            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync();
        }
    }
}
