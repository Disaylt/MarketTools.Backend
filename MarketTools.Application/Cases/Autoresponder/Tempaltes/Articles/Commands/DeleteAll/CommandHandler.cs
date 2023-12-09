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
        (IUnitOfWork _unitOfWork,
        IAuthReadHelper _authReadHelper)
        : IRequestHandler<DeleteAllArticlesCommand>
    {
        private readonly DbSet<AutoresponderTemplateArticle> _dbSet = _unitOfWork.GetDbSet<AutoresponderTemplateArticle>();
        public Task Handle(DeleteAllArticlesCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
