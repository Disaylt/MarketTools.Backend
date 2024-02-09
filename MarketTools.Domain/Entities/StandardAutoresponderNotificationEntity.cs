using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderNotificationEntity : BaseEntity
    {
        public string Response { get; set; } = string.Empty;
        public string Report { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public int StandardAutoresponderConnectionId { get; set; }
        public StandardAutoresponderConnectionEntity StandardAutoresponderConnection { get; set; } = null!;
    }
}
