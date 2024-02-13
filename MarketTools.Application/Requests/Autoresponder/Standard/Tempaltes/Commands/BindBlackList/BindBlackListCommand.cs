using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Commands.BindBlackList
{
    public class BindBlackListCommand : IRequest<Unit>
    {
        public int TemplateId { get; set; }
        public int BlackListId { get; set; }
    }
}
