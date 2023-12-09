using MarketTools.Application.Cases.Autoresponder.Tempaltes.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Queries.GetList
{
    public class GetTemplatesListQuery : IRequest<IEnumerable<TemplateVm>>
    {

    }
}
