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
        private readonly IAuthRepository<AutoresponderTemplate> _repository = _authUnitOfWork.AutoresponderTemplates;
        public async Task Handle(DefaultDeleteCommand<AutoresponderTemplate> request, CancellationToken cancellationToken)
        {
            AutoresponderTemplate entity = await _repository.FirstAsync(x => x.Id == request.Id);
            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync();
        }
    }
}
