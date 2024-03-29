﻿using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Requests.Autoresponder.Standard.ColumnBindPosition.Commands.UpdateRange;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
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
        : IRequestHandler<BindPositionUpdateRangeCommand, Unit>
    {
        private readonly IRepository<StandardAutoresponderBindPositionEntity> _repository = _authUnintOfWork.GetRepository<StandardAutoresponderBindPositionEntity>();

        public async Task<Unit> Handle(BindPositionUpdateRangeCommand request, CancellationToken cancellationToken)
        {
            await RemoveCurrentBindsAsync(request.TemplateId, request.ColumnType, cancellationToken);

            IEnumerable<StandardAutoresponderBindPositionEntity> entities = CreateEntities(request);

            await _repository.AddRangeAsync(entities, cancellationToken);
            await _authUnintOfWork.CommintAsync(cancellationToken);

            return Unit.Value;
        }

        private IEnumerable<StandardAutoresponderBindPositionEntity> CreateEntities(BindPositionUpdateRangeCommand request)
        {
            return request.BindPositions
                .Select(x => new StandardAutoresponderBindPositionEntity
                {
                    ColumnId = x.ColumnId,
                    Position = x.Position,
                    TemplateId = request.TemplateId
                });
        }

        private async Task RemoveCurrentBindsAsync(int templateId, AutoresponderColumnType columnType, CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderBindPositionEntity> currentEntites = await _repository
                .GetRangeAsync(x => x.TemplateId == templateId && x.Column.Type == columnType, cancellationToken);

            _repository.RemoveRange(currentEntites);
        }
    }
}
