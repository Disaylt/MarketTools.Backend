using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AutoresponderConnectionRating
    {
        public int Rating { get; set; }
        public int ConnectionId { get; set; }
        public AutoresponderConnection Connection { get; set; } = null!;

        public int? MainTemplateId { get; set; }
        public AutoresponderTemplate? MainTemplate { get; set; }
        public List<AutoresponderTemplate> Templates { get; set; } = new List<AutoresponderTemplate>();

        public int? BindAutoresponerBlackListId { get; set; }
        public AutoresponderBlackList? BindAutoresponerBlackList { get; set; }
    }
}
