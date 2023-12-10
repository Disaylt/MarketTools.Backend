using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Settings.Commands.Update
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<UpdateCommand>
    {
        public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            AutoresponderTemplateSettings entity = await FindAsync(request.TemplateId, cancellationToken);
            Change(entity, request);

            _authUnitOfWork.AutoresponderTemplateSettings.Update(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }

        private void Change(AutoresponderTemplateSettings entity, UpdateCommand request)
        {
            entity.AsMainTemplate = request.AsMainTemplate;
            entity.IsSkipWithTextFeedbacks = request.IsSkipWithTextFeedbacks;
            entity.IsSkipEmptyFeedbacks = request.IsSkipEmptyFeedbacks;
        }

        private async Task<AutoresponderTemplateSettings> FindAsync(int id, CancellationToken ct)
        {
            return await _authUnitOfWork.AutoresponderTemplateSettings
                .FirstAsync(x => x.TemplateId == id, ct);
        }
    }
}
