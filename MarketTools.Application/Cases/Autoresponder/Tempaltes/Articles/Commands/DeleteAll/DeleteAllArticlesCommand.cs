using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Commands.DeleteAll
{
    public class DeleteAllArticlesCommand : IRequest
    {
        public int TemplateId { get; set; }
    }
}
