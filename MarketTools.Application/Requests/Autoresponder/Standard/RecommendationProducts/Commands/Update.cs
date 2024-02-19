using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands
{
    public class RecommendationProductUpdateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public required string FeedbackArticle { get; set; }
        public string? FeedbackProductName { get; set; }
        public string? RecommendationArticle { get; set; }
        public string? RecommendationProductName { get; set; }
    }

    public class UpdateCommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<RecommendationProductUpdateCommand, Unit>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();
        public async Task<Unit> Handle(RecommendationProductUpdateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderRecommendationProductEntity autoresponderRecommendationProduct = await _repository.FirstAsync(x => x.Id == request.Id);
            Change(request, autoresponderRecommendationProduct);
            _repository.Update(autoresponderRecommendationProduct);
            await _authUnitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }

        private void Change(RecommendationProductUpdateCommand request, StandardAutoresponderRecommendationProductEntity autoresponderRecommendationProduct)
        {
            autoresponderRecommendationProduct.FeedbackArticle = request.FeedbackArticle;
            autoresponderRecommendationProduct.RecommendationArticle = request.RecommendationArticle;
            autoresponderRecommendationProduct.FeedbackProductName = request.FeedbackProductName;
            autoresponderRecommendationProduct.RecommendationProductName = request.RecommendationProductName;
        }
    }
}
