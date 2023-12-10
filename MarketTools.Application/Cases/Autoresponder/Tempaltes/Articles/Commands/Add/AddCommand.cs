using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Commands.Add
{
    public class AddCommand : TemplateBasicCommand, IRequest<ArticleVm>
    {
        public required string Article { get; set; }
    }
}
