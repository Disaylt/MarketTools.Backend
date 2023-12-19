using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AutoresponderStandardConnectionRating
    {
        public int Rating { get; set; }
        public int ConnectionId { get; set; }
        public AutoresponderStandardConnection Connection { get; set; } = null!;

        public List<AutoresponderStandardTemplate> Templates { get; set; } = new List<AutoresponderStandardTemplate>();

        public int? BindAutoresponerBlackListId { get; set; }
        public AutoresponderStandardBlackList? BindAutoresponerBlackList { get; set; }
    }
}
