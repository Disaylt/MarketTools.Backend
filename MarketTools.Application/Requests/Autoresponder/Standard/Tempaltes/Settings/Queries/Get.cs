using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Settings.Queries
{
    public class SettingsGetQuery : IRequest<StandardAutoresponderTemplateSettingsEntity>
    {
        public int TemplateId { get; set; }
    }

    public class GetCommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<SettingsGetQuery, StandardAutoresponderTemplateSettingsEntity>
    {
        private readonly IRepository<StandardAutoresponderTemplateSettingsEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderTemplateSettingsEntity>();

        public async Task<StandardAutoresponderTemplateSettingsEntity> Handle(SettingsGetQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync(x => x.TemplateId == request.TemplateId);
        }
    }
}
