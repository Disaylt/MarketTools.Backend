
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Queries.GetRange
{
    public class TemplateGetRangeQuery : IRequest<IEnumerable<StandardAutoresponderTemplateEntity>>
    {

    }
}
