﻿using MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Commands.Update
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<UpdateCommand>
    {
        public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            AutoresponderRecommendationProduct autoresponderRecommendationProduct = await _authUnitOfWork.AutoresponderRecommendationProducts
                .FirstAsync(x => x.Id == request.Id);
            Change(request, autoresponderRecommendationProduct);
            _authUnitOfWork.AutoresponderRecommendationProducts.Update(autoresponderRecommendationProduct);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }

        private void Change(UpdateCommand request, AutoresponderRecommendationProduct autoresponderRecommendationProduct)
        {
            autoresponderRecommendationProduct.FeedbackArticle = request.FeedbackArticle;
            autoresponderRecommendationProduct.RecommendationArticle = request.RecommendationArticle;
            autoresponderRecommendationProduct.FeedbackProductName = request.FeedbackProductName;
            autoresponderRecommendationProduct.RecommendationProductName = request.RecommendationProductName;
        }
    }
}
