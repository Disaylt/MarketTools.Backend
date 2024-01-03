using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Settings.Commands.Update
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<UpdateCommand>
    {
        private readonly IRepository<StandardAutoresponderTemplateSettings> _repository = _authUnitOfWork.StandardAutoresponderTemplateSettings;
        public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateSettings entity = await _repository
                .FirstAsync(x => x.TemplateId == request.TemplateId, cancellationToken);

            Change(entity, request);

            _repository.Update(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }

        private void Change(StandardAutoresponderTemplateSettings entity, UpdateCommand request)
        {
            entity.AsMainTemplate = request.AsMainTemplate;
            entity.IsSkipWithTextFeedbacks = request.IsSkipWithTextFeedbacks;
            entity.IsSkipEmptyFeedbacks = request.IsSkipEmptyFeedbacks;
        }
    }
}
