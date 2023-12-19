using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Commands.Add
{
    public class CommandHandler
        (IMapper _mapper,
        IUnitOfWork _unitOfWork,
        IAuthReadHelper _authReadHelper)
        : IRequestHandler<AddCommand, TemplateVm>
    {
        private readonly IRepository<AutoresponderStandardTemplate> _repository = _unitOfWork.GetRepository<AutoresponderStandardTemplate>();

        public async Task<TemplateVm> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            AutoresponderStandardTemplate entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync();

            return _mapper.Map<TemplateVm>(entity);
        }

        private AutoresponderStandardTemplate Build(AddCommand request)
        {
            return new AutoresponderStandardTemplate
            {
                Name = request.Name,
                UserId = _authReadHelper.UserId
            };
        }
    }
}
