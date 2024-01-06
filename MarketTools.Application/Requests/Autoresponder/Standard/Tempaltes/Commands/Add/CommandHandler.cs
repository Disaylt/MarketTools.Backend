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
        : IRequestHandler<AddCommand, StandardAutoresponderTemplate>
    {
        private readonly IRepository<StandardAutoresponderTemplate> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplate>();

        public async Task<StandardAutoresponderTemplate> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplate entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync();

            return entity;
        }

        private StandardAutoresponderTemplate Build(AddCommand request)
        {
            return new StandardAutoresponderTemplate
            {
                Name = request.Name,
                UserId = _authReadHelper.UserId
            };
        }
    }
}
