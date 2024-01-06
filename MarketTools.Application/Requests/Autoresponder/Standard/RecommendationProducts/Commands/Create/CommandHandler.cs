using AutoMapper;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Commands.Create
{
    public class CommandHandler
        (IMapper _mapper,
        IUnitOfWork _unitOfWork,
        IAuthReadHelper _authReadHelper)
        : IRequestHandler<CreateCommand, StandardAutoresponderRecommendationProductEntity>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();

        public async Task<StandardAutoresponderRecommendationProductEntity> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderRecommendationProductEntity entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return entity;
        }

        private StandardAutoresponderRecommendationProductEntity Build(CreateCommand request)
        {
            StandardAutoresponderRecommendationProductEntity entity = _mapper.Map<StandardAutoresponderRecommendationProductEntity>(request);
            entity.UserId = _authReadHelper.UserId;

            return entity;
        }
    }
}
