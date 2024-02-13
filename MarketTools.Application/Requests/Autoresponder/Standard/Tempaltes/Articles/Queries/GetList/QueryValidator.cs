using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Requests.Autoresponder.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Queries.GetList
{
    public class QueryValidator : CommonValidator<ArticleGetArticlesQuery>
    {
        public QueryValidator(IAuthUnitOfWork authUnitOfWork)
        {
            CanIntercatTemplate(RuleFor(x => x.TemplateId), authUnitOfWork);
        }
    }
}
