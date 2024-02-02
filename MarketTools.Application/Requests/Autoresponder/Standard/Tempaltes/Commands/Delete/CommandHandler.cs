using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Requests;
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
        : IRequestHandler<GenericDeleteCommand<StandardAutoresponderTemplateEntity>>
    {
        private readonly IRepository<StandardAutoresponderTemplateEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderTemplateEntity>();
        public async Task Handle(GenericDeleteCommand<StandardAutoresponderTemplateEntity> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateEntity entity = await _repository.FirstAsync(x => x.Id == request.Id);
            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync();
        }
    }
}
