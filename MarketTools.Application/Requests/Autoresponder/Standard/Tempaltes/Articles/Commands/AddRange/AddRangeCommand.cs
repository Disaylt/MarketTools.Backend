using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Models;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.AddRange
{
    public class AddRangeCommand : TemplateBasicCommand, IRequest<IEnumerable<StandardAutoresponderTemplateArticle>>
    {
        public required IEnumerable<string> Articles { get; set; }
    }
}
