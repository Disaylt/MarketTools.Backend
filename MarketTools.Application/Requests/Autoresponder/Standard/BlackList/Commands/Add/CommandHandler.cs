using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.Commands.Add
{
    public class CommandHandler(IAuthReadHelper _authReadHelper,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<BlackListAddCommand, StandardAutoresponderBlackListEntity>
    {

        private readonly IRepository<StandardAutoresponderBlackListEntity> _repsitory = _unitOfWork.GetRepository<StandardAutoresponderBlackListEntity>();

        public async Task<StandardAutoresponderBlackListEntity> Handle(BlackListAddCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderBlackListEntity entity = Create(request);
            await _repsitory.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return entity;
        }

        private StandardAutoresponderBlackListEntity Create(BlackListAddCommand request)
        {
            return new StandardAutoresponderBlackListEntity
            {
                UserId = _authReadHelper.UserId,
                Name = request.Name
            };
        }
    }
}
