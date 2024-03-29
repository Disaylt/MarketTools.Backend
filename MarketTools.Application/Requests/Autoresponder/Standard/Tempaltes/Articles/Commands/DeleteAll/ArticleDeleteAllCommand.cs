﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.DeleteAll
{
    public class ArticleDeleteAllCommand : IRequest<Unit>
    {
        public int TemplateId { get; set; }
    }
}
