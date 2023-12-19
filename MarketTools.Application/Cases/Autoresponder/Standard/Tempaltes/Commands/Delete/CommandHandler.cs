using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Commands.Delete
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<StandardAutoresponderTemplate>>
    {
        private readonly IAuthRepository<StandardAutoresponderTemplate> _repository = _authUnitOfWork.StandardAutoresponderTemplates;
        public async Task Handle(DefaultDeleteCommand<StandardAutoresponderTemplate> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplate entity = await _repository.FirstAsync(x => x.Id == request.Id);
            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync();
        }
    }
}
