using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Builders;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands.AddRange
{
    public class CommandHandler(IAuthReadHelper _authReadHelper,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<RecommendationProductAddRangeCommand, IEnumerable<StandardAutoresponderRecommendationProductEntity>>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();

        public async Task<IEnumerable<StandardAutoresponderRecommendationProductEntity>> Handle(RecommendationProductAddRangeCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderRecommendationProductEntity> products = new DetailsBuilder(request)
                .AddMainDetails(_authReadHelper.UserId)
                .Build();

            await _repository.AddRangeAsync(products);
            await _unitOfWork.CommintAsync(cancellationToken);

            return products;
        }
    }
}
