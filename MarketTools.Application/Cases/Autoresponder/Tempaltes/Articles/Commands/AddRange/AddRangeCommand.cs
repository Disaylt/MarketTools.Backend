using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Commands.AddRange
{
    public class AddRangeCommand : TemplateBasicCommand, IRequest<IEnumerable<ArticleVm>>
    {
        public required IEnumerable<string> Articles { get; set; }
    }
}
