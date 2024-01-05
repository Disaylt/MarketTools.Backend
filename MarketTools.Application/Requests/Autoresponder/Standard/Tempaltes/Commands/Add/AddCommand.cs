using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Commands.Add
{
    public class AddCommand : IRequest<TemplateVm>
    {
        public required string Name { get; set; }
    }
}
