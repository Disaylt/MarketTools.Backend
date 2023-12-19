using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Commands.Delete
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DefaultDeleteCommand<StandardAutoresponderRecommendationProduct>>
    {
        private readonly IAuthRepository<StandardAutoresponderRecommendationProduct> _repository = _authUnitOfWork.StandardAutoresponderRecommendationProducts;
        public async Task Handle(DefaultDeleteCommand<StandardAutoresponderRecommendationProduct> request, CancellationToken cancellationToken)
        {
            StandardAutoresponderRecommendationProduct entity = await _repository.FirstAsync(x => x.Id == request.Id);
            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
