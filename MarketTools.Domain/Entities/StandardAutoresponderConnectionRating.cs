using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderConnectionRating
    {
        public int Rating { get; set; }
        public int ConnectionId { get; set; }
        public StandardAutoresponderConnection Connection { get; set; } = null!;

        public List<StandardAutoresponderTemplate> Templates { get; set; } = new List<StandardAutoresponderTemplate>();

        public int? BindAutoresponerBlackListId { get; set; }
        public StandardAutoresponderBlackList? BindAutoresponerBlackList { get; set; }
    }
}
