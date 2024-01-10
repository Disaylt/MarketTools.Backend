using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Commands.BindBlackList
{
    public class CommandHandler(IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<BindBlackListCommand>
    {
        private readonly IRepository<StandardAutoresponderTemplateEntity> _templateRepository = _authUnitOfWork.StandardAutoresponderTemplates;
        private readonly IRepository<StandardAutoresponderBlackListEntity> _blackListRepository = _authUnitOfWork.StandardAutoresponderBlackLists;

        public async Task Handle(BindBlackListCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateEntity templateEntity = await _templateRepository.FirstAsync(x => x.Id == request.TemplateId, cancellationToken);
            await BindBlackListAsync(templateEntity, request.BlackListId, cancellationToken);

            _templateRepository.Update(templateEntity);
            await _authUnitOfWork.CommintAsync(cancellationToken);
        }

        private async Task BindBlackListAsync(StandardAutoresponderTemplateEntity templateEntity, int blackListId, CancellationToken cancellationToken)
        {
            if (blackListId == 0)
            {
                templateEntity.BlackListId = null;
                return;
            }
            else
            {
                StandardAutoresponderBlackListEntity blackList = await _blackListRepository.FirstAsync(x=> x.Id == blackListId, cancellationToken);
                templateEntity.BlackListId = blackList.Id;
                templateEntity.BlackList = blackList;
            }

        }
    }
}
