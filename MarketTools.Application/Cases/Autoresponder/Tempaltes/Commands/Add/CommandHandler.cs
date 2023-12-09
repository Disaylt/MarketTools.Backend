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
        : IRequestHandler<AddTemplateCommand, TemplateVm>
    {
        private readonly IRepository<AutoresponderTemplate> _repository = _unitOfWork.GetRepository<AutoresponderTemplate>();

        public async Task<TemplateVm> Handle(AddTemplateCommand request, CancellationToken cancellationToken)
        {
            AutoresponderTemplate entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync();

            return _mapper.Map<TemplateVm>(entity);
        }

        private AutoresponderTemplate Build(AddTemplateCommand request)
        {
            return new AutoresponderTemplate
            {
                Name = request.Name,
                UserId = _authReadHelper.UserId
            };
        }
    }
}
