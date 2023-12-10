﻿using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Commands.Delete
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<AutoresponderRecommendationProduct>>
    {
        public async Task Handle(DefaultDeleteCommand<AutoresponderRecommendationProduct> request, CancellationToken cancellationToken)
        {
            AutoresponderRecommendationProduct entity = await _authUnitOfWork.AutoresponderRecommendationProducts
                .FirstAsync(x => x.Id == request.Id);
            _authUnitOfWork.AutoresponderRecommendationProducts.Remove(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
