using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Commands.Delete
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<AutoresponderTemplate>>
    {
        public async Task Handle(DefaultDeleteCommand<AutoresponderTemplate> request, CancellationToken cancellationToken)
        {
            AutoresponderTemplate entity = await _authUnitOfWork.AutoresponderTemplates
                .FirstAsync(x => x.Id == request.Id);
            _authUnitOfWork.AutoresponderTemplates.Remove(entity);
            await _authUnitOfWork.CommintAsync();
        }
    }
}
