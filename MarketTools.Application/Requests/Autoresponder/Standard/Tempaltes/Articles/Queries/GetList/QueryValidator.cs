using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Validatiors;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Queries.GetList
{
    public class QueryValidator : TemplateInteractValidator<ArticleGetArticlesQuery>
    {
        public QueryValidator(IAuthUnitOfWork authUnitOfWork) : base(authUnitOfWork)
        {
        }
    }
}
