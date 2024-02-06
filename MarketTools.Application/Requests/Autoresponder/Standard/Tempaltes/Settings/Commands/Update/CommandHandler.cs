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
        : IRequestHandler<SettingsUpdateCommand, StandardAutoresponderTemplateSettingsEntity>
    {
        private readonly IRepository<StandardAutoresponderTemplateSettingsEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderTemplateSettingsEntity>();
        public async Task<StandardAutoresponderTemplateSettingsEntity> Handle(SettingsUpdateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateSettingsEntity entity = await _repository
                .FirstAsync(x => x.TemplateId == request.TemplateId, cancellationToken);

            Change(entity, request);

            _repository.Update(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);

            return entity;
        }

        private void Change(StandardAutoresponderTemplateSettingsEntity entity, SettingsUpdateCommand request)
        {
            entity.IsSkipWithTextFeedbacks = request.IsSkipWithTextFeedbacks;
            entity.IsSkipEmptyFeedbacks = request.IsSkipEmptyFeedbacks;
        }
    }
}
