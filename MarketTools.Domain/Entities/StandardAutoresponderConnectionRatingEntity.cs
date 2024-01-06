using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderConnectionRatingEntity
    {
        public int Rating { get; set; }
        public int ConnectionId { get; set; }
        public StandardAutoresponderConnectionEntity Connection { get; set; } = null!;

        public List<StandardAutoresponderTemplateEntity> Templates { get; set; } = new List<StandardAutoresponderTemplateEntity>();

        public int? BindAutoresponerBlackListId { get; set; }
        public StandardAutoresponderBlackListEntity? BindAutoresponerBlackList { get; set; }
    }
}
