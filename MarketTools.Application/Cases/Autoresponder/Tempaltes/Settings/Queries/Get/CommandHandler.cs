using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Settings.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Settings.Queries.Get
{
    internal class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork,
        IMapper _mapper)
        : IRequestHandler<GetCommand, SettingsVm>
    {
        private readonly IAuthRepository<AutoresponderStandardTemplateSettings> _repository = _authUnitOfWork.AutoresponderTemplateSettings;

        public async Task<SettingsVm> Handle(GetCommand request, CancellationToken cancellationToken)
        {
            AutoresponderStandardTemplateSettings entity = await _repository
                .FirstAsync(x=> x.TemplateId == request.TemplateId);
            
            return _mapper.Map<SettingsVm>(entity);
        }
    }
}
