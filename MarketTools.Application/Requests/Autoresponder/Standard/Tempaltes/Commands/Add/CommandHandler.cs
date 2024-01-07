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

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Commands.Add
{
    public class CommandHandler
        (IUnitOfWork _unitOfWork,
        IAuthReadHelper _authReadHelper)
        : IRequestHandler<TemplateAddCommand, StandardAutoresponderTemplateEntity>
    {
        private readonly IRepository<StandardAutoresponderTemplateEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplateEntity>();

        public async Task<StandardAutoresponderTemplateEntity> Handle(TemplateAddCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateEntity entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync();

            return entity;
        }

        private StandardAutoresponderTemplateEntity Build(TemplateAddCommand request)
        {
            return new StandardAutoresponderTemplateEntity
            {
                Name = request.Name,
                UserId = _authReadHelper.UserId
            };
        }
    }
}
