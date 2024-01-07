using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
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
        : IRequestHandler<AddRangeCommand, IEnumerable<StandardAutoresponderRecommendationProductEntity>>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();

        public async Task<IEnumerable<StandardAutoresponderRecommendationProductEntity>> Handle(AddRangeCommand request, CancellationToken cancellationToken)
        {
            AddDetails(request);
            await _repository.AddRangeAsync(request.Products, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return request.Products;
        }

        private void AddDetails(AddRangeCommand request)
        {
            foreach(StandardAutoresponderRecommendationProductEntity entity in request.Products)
            {
                entity.UserId = _authReadHelper.UserId;
                entity.MarketplaceName = request.MarketplaceName;
            }
        }
    }
}
