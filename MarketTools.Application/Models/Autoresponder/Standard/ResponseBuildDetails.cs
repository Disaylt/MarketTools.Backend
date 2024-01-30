using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Autoresponder.Standard
{
    public class ResponseBuildDetails
    {
        public IEnumerable<StandardAutoresponderTemplateEntity> Templates { get; set; } = Enumerable.Empty<StandardAutoresponderTemplateEntity>();
        public AutoresponderColumnType ColumnType { get; set; }
    }
}
