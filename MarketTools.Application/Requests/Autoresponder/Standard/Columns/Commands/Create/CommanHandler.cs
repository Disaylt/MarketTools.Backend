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
        : IRequestHandler<CreateCommand, StandardAutoresponderColumn>
    {
        private readonly IRepository<StandardAutoresponderColumn> _repository = _unitOfWork.GetRepository<StandardAutoresponderColumn>();

        public async Task<StandardAutoresponderColumn> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderColumn entity = Create(request);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommintAsync();

            return entity;
        }

        private StandardAutoresponderColumn Create(CreateCommand request)
        {
            return new StandardAutoresponderColumn
            {
                Name = request.Name,
                Type = request.Type,
                UserId = _authReadHelper.UserId,
            };
        }
    }
}
