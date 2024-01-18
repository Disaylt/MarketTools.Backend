using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Models;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Articles.Commands.EditRange
{
    public class ArticlesEditRangeCommand : TemplateBasicCommand, IRequest<IEnumerable<StandardAutoresponderTemplateArticleEntity>>
    {
        public required IEnumerable<string> Articles { get; set; }
    }
}
