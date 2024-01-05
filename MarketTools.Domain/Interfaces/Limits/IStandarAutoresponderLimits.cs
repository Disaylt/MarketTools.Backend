using MarketTools.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Interfaces.Limits
{
    public interface IStandarAutoresponderLimits : ILimitModel
    {
        public int MaxBanWords { get; set; }
        public int MaxBlackList { get; set; }
        public int MaxCells { get; set; }
        public int MaxColumns { get; set; }
        public int MaxRecommendationProducts { get; set; }
        public int MaxTemplates { get; set; }
        public int MaxTemplateArticles { get; set; }
    }
}
