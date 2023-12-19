using MarketTools.Application.Interfaces.Database;
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
        : IRequestHandler<DefaultDeleteCommand<AutoresponderStandardRecommendationProduct>>
    {
        private readonly IAuthRepository<AutoresponderStandardRecommendationProduct> _repository = _authUnitOfWork.AutoresponderRecommendationProducts;
        public async Task Handle(DefaultDeleteCommand<AutoresponderStandardRecommendationProduct> request, CancellationToken cancellationToken)
        {
            AutoresponderStandardRecommendationProduct entity = await _repository.FirstAsync(x => x.Id == request.Id);
            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
