using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Settings.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Settings.Queries.Get
{
    public class GetCommand : IRequest<SettingsVm>
    {
        public int TemplateId { get; set; }
    }
}
