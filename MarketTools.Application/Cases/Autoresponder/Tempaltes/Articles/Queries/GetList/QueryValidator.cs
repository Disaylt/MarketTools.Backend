﻿using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Validations;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Queries.GetList
{
    public class QueryValidator : TemplateInteractValidator<GetArticlesQuery>
    {
        public QueryValidator(IAuthUnitOfWork authUnitOfWork) : base(authUnitOfWork)
        {
        }
    }
}
