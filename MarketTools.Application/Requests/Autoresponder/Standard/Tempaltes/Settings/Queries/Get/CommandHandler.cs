using AutoMapper;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Settings.Queries.Get
{
    internal class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetCommand, StandardAutoresponderTemplateSettings>
    {
        private readonly IRepository<StandardAutoresponderTemplateSettings> _repository = _authUnitOfWork.StandardAutoresponderTemplateSettings;

        public async Task<StandardAutoresponderTemplateSettings> Handle(GetCommand request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync(x => x.TemplateId == request.TemplateId);
        }
    }
}
