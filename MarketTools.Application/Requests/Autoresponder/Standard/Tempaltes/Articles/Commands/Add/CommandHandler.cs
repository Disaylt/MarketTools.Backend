using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.Add
{
    public class CommandHandler
        (IUnitOfWork _unitOfWork)
        : IRequestHandler<ArticleAddCommand, StandardAutoresponderTemplateArticleEntity>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticleEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();

        public async Task<StandardAutoresponderTemplateArticleEntity> Handle(ArticleAddCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateArticleEntity entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return entity;
        }

        private StandardAutoresponderTemplateArticleEntity Build(ArticleAddCommand request)
        {
            return new StandardAutoresponderTemplateArticleEntity
            {
                Article = request.Article,
                TemplateId = request.TemplateId
            };
        }
    }
}
