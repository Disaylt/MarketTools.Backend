using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Autoresponder.Standard
{
    public class TemplateDetails
    {
        public required StandardAutoresponderTemplateEntity Template { get; set; }
        public AutoresponderColumnType ColumnType { get; set; }
    }
}
