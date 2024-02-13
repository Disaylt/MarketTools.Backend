using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class UserNotificationEntity : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public bool IsRead { get; set; } 

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;
    }
}
