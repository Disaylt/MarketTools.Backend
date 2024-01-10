using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Settings.Commands.Update
{
    public class SettingsUpdateCommand : IRequest<StandardAutoresponderTemplateSettingsEntity>
    {
        public int TemplateId { get; set; }
        public bool IsSkipWithTextFeedbacks { get; set; }
        public bool IsSkipEmptyFeedbacks { get; set; }
    }
}
