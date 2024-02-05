using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Commands.Update
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<UpdateCommand, Unit>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();
        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderRecommendationProductEntity autoresponderRecommendationProduct = await _repository.FirstAsync(x => x.Id == request.Id);
            Change(request, autoresponderRecommendationProduct);
            _repository.Update(autoresponderRecommendationProduct);
            await _authUnitOfWork.CommintAsync(cancellationToken);

            return Unit.Value;
        }

        private void Change(UpdateCommand request, StandardAutoresponderRecommendationProductEntity autoresponderRecommendationProduct)
        {
            autoresponderRecommendationProduct.FeedbackArticle = request.FeedbackArticle;
            autoresponderRecommendationProduct.RecommendationArticle = request.RecommendationArticle;
            autoresponderRecommendationProduct.FeedbackProductName = request.FeedbackProductName;
            autoresponderRecommendationProduct.RecommendationProductName = request.RecommendationProductName;
        }
    }
}
