using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Builders;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands.ReplaceRange
{
    public class CommandHandler(IAuthReadHelper _authReadHelper,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<RecommendationProductReplaceRangeCommand, IEnumerable<StandardAutoresponderRecommendationProductEntity>>
    {

        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();

        public async Task<IEnumerable<StandardAutoresponderRecommendationProductEntity>> Handle(RecommendationProductReplaceRangeCommand request, CancellationToken cancellationToken)
        {
            await _repository.ExecuteDeleteAsync(x=> x.UserId == _authReadHelper.UserId);

            IEnumerable<StandardAutoresponderRecommendationProductEntity> products = new DetailsBuilder(request)
                .AddMainDetails(_authReadHelper.UserId)
                .Build();

            await _repository.AddRangeAsync(products, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return products;
        }
    }
}
