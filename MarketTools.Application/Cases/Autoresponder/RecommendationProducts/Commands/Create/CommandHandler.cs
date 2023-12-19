using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Commands.Create
{
    public class CommandHandler
        (IMapper _mapper,
        IUnitOfWork _unitOfWork,
        IAuthReadHelper _authReadHelper)
        : IRequestHandler<CreateCommand, RecommendationProductVm>
    {
        private readonly IRepository<StandardAutoresponderRecommendationProduct> _repository = _unitOfWork.GetRepository<StandardAutoresponderRecommendationProduct>();

        public async Task<RecommendationProductVm> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderRecommendationProduct entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return _mapper.Map<RecommendationProductVm>(entity);
        }

        private StandardAutoresponderRecommendationProduct Build(CreateCommand request)
        {
            StandardAutoresponderRecommendationProduct entity = _mapper.Map<StandardAutoresponderRecommendationProduct>(request);
            entity.UserId = _authReadHelper.UserId;

            return entity;
        }
    }
}
