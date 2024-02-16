﻿using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Requests;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands
{
    public class DeleteCommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GenericDeleteCommand<StandardAutoresponderRecommendationProductEntity>, Unit>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();
        public async Task<Unit> Handle(GenericDeleteCommand<StandardAutoresponderRecommendationProductEntity> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderRecommendationProductEntity entity = await _repository.FirstAsync(x => x.Id == request.Id);
            _repository.Remove(entity);
            await _authUnitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
