using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Autoresponder.Standard.Models
{
    public class StandardAutoresponderLimitsDto : IStandarAutoresponderLimits
    {
        public int MaxBanWords { get; set; } = 100;
        public int MaxBlackList { get; set; } = 10;
        public int MaxCells { get; set; } = 100;
        public int MaxColumns { get; set; } = 100;
        public int MaxRecommendationProducts { get; set; } = 1000;
        public int MaxTemplates { get; set; } = 100;
        public int MaxTemplateArticles { get; set; } = 1000;
    }
}
