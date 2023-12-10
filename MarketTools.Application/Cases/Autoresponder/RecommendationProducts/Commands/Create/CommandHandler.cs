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
        (IMediator _mediator,
        IMapper _mapper,
        IUnitOfWork _unitOfWork,
        IAuthReadHelper _authReadHelper)
        : IRequestHandler<CreateCommand, RecommendationProductVm>
    {
        private readonly IRepository<AutoresponderRecommendationProduct> _repository = _unitOfWork.GetRepository<AutoresponderRecommendationProduct>();

        public async Task<RecommendationProductVm> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            AutoresponderRecommendationProduct entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return _mapper.Map<RecommendationProductVm>(entity);
        }

        private AutoresponderRecommendationProduct Build(CreateCommand request)
        {
            AutoresponderRecommendationProduct entity = _mapper.Map<AutoresponderRecommendationProduct>(request);
            entity.UserId = _authReadHelper.UserId;

            return entity;
        }
    }
}
