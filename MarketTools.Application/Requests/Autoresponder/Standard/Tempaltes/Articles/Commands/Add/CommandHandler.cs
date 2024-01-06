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
        : IRequestHandler<AddCommand, StandardAutoresponderTemplateArticle>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticle> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplateArticle>();

        public async Task<StandardAutoresponderTemplateArticle> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateArticle entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return entity;
        }

        private StandardAutoresponderTemplateArticle Build(AddCommand request)
        {
            return new StandardAutoresponderTemplateArticle
            {
                Article = request.Article,
                TemplateId = request.TemplateId
            };
        }
    }
}
