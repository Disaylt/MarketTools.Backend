using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Commands.DeleteAll
{
    public class CommandHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<DeleteAllCommand>
    {
        private readonly IAuthRepository<StandardAutoresponderTemplateArticle> _repository = _authUnitOfWork.AutoresponderTemplateArticles;
        public async Task Handle(DeleteAllCommand request, CancellationToken cancellationToken)
        {
            await _repository.ExecuteDeleteAsync(x => x.TemplateId == request.TemplateId);
        }
    }
}
