﻿using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.DeleteScore
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<RatingDeleteScoreCommand>
    {
        private readonly IRepository<StandardAutoresponderConnectionRatingEntity> _repository = _authUnitOfWork.StandardAutoresponderConnectionRatings;

        public async Task Handle(RatingDeleteScoreCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderConnectionRatingEntity entity = await _repository
                .FirstAsync(x=> x.ConnectionId == request.ConnectionId && x.Rating == x.Rating, cancellationToken);

            _repository.Remove(entity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }
    }
}
