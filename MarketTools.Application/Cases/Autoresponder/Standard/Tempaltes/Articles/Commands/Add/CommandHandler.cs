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
        (IMapper _mapper,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<AddCommand, ArticleVm>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticle> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplateArticle>();

        public async Task<ArticleVm> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderTemplateArticle entity = Build(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return _mapper.Map<ArticleVm>(entity);
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
