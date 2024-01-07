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

namespace MarketTools.Application.Cases.Autoresponder.Standard.Columns.Commands.Create
{
    public class CommanHandler(IUnitOfWork _unitOfWork,
        IAuthReadHelper _authReadHelper)
        : IRequestHandler<ColumnCreateCommand, StandardAutoresponderColumnEntity>
    {
        private readonly IRepository<StandardAutoresponderColumnEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderColumnEntity>();

        public async Task<StandardAutoresponderColumnEntity> Handle(ColumnCreateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderColumnEntity entity = Create(request);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommintAsync();

            return entity;
        }

        private StandardAutoresponderColumnEntity Create(ColumnCreateCommand request)
        {
            return new StandardAutoresponderColumnEntity
            {
                Name = request.Name,
                Type = request.Type,
                UserId = _authReadHelper.UserId,
            };
        }
    }
}
