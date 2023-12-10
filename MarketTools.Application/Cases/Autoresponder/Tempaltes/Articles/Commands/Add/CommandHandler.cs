using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Commands.Add
{
    public class CommandHandler
        (IMapper _mapper,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<AddCommand, ArticleVm>
    {
        private readonly IRepository<AutoresponderTemplateArticle> _repository = _unitOfWork.GetRepository<AutoresponderTemplateArticle>();

        public async Task<ArticleVm> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            AutoresponderTemplateArticle entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return _mapper.Map<ArticleVm>(entity);
        }

        private AutoresponderTemplateArticle Build(AddCommand request)
        {
            return new AutoresponderTemplateArticle
            {
                Article = request.Article,
                TemplateId = request.TemplateId
            };
        }
    }
}
