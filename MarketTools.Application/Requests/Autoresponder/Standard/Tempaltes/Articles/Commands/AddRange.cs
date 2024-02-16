using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Models;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Limits;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Articles.Commands
{
    public class ArticleAddRangeCommand : TemplateBasicCommand, IRequest<IEnumerable<StandardAutoresponderTemplateArticleEntity>>
    {
        public required IEnumerable<string> Articles { get; set; }
    }

    public class AddRangeCommandValidator : CommonValidator<ArticleAddRangeCommand>
    {
        public AddRangeCommandValidator(IAuthUnitOfWork authUnitOfWork,
            ILimitsService<IStandarAutoresponderLimits> limitsService)
        {
            CanIntercatTemplate(RuleFor(x => x.TemplateId), authUnitOfWork);
            MustMaxQuantityTemplateArticlesAtOnce(RuleFor(x => x.Articles));
            MustMaxQuantityTemplateArticles(RuleFor(x => x.Articles), authUnitOfWork, limitsService);
        }
    }

    public class AddRangeCommandHandler
        (IUnitOfWork _unitOfWork)
        : IRequestHandler<ArticleAddRangeCommand, IEnumerable<StandardAutoresponderTemplateArticleEntity>>
    {
        private readonly IRepository<StandardAutoresponderTemplateArticleEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderTemplateArticleEntity>();
        public async Task<IEnumerable<StandardAutoresponderTemplateArticleEntity>> Handle(ArticleAddRangeCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderTemplateArticleEntity> newEntities = await BuildOnlyNewArticlesAsync(request, cancellationToken);
            await _repository.AddRangeAsync(newEntities, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return newEntities;
        }

        private async Task<IEnumerable<StandardAutoresponderTemplateArticleEntity>> BuildOnlyNewArticlesAsync(ArticleAddRangeCommand request, CancellationToken ct)
        {
            IEnumerable<StandardAutoresponderTemplateArticleEntity> currentEntities = await _repository.GetRangeAsync(x => x.TemplateId == request.TemplateId, ct);

            return request.Articles
                .Where(article => currentEntities.Any(entity => entity.Value == article) == false)
                .Select(x => new StandardAutoresponderTemplateArticleEntity
                {
                    Value = x,
                    TemplateId = request.TemplateId,
                });
        }
    }
}
