﻿using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Queries.GetList
{
    public class GetArticlesQuery : TemplateBasicCommand, IRequest<IEnumerable<ArticleVm>>
    {

    }
}