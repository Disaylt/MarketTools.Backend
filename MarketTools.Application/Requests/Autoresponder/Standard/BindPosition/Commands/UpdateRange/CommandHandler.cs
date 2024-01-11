using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Requests.Autoresponder.Standard.ColumnBindPosition.Commands.UpdateRange;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BindPosition.Commands.UpdateRange
{
    public class CommandHandler(IAuthUnitOfWork _authUnintOfWork)
        : IRequestHandler<BindPositionUpdateRangeCommand>
    {
        private readonly IRepository<StandardAutoresponderColumnBindPositionEntity> _repository = _authUnintOfWork.StandardAutoresponderColumnBindPositions;

        public async Task Handle(BindPositionUpdateRangeCommand request, CancellationToken cancellationToken)
        {
            await RemoveCurrentBindsAsync(request.TemplateId, cancellationToken);

            IEnumerable<StandardAutoresponderColumnBindPositionEntity> entities = CreateEntities(request);

            await _repository.AddRangeAsync(entities, cancellationToken);
            await _authUnintOfWork.CommintAsync(cancellationToken);
        }

        private IEnumerable<StandardAutoresponderColumnBindPositionEntity> CreateEntities(BindPositionUpdateRangeCommand request)
        {
            return request.BindPositions
                .Select(x => new StandardAutoresponderColumnBindPositionEntity
                {
                    ColumnId = x.ColumnId,
                    Position = x.Position,
                    TemplateId = request.TemplateId
                });
        }

        private async Task RemoveCurrentBindsAsync(int templateId, CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderColumnBindPositionEntity> currentEntites = await _repository
                .GetRangeAsync(x => x.TemplateId == templateId, cancellationToken);

            _repository.RemoveRange(currentEntites);
        }
    }
}
