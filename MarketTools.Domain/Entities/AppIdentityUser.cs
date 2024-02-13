using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AppIdentityUser : IdentityUser
    {
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public List<StandardAutoresponderRecommendationProductEntity> StandardAutoresponderRecommendationProducts { get; set; } = new List<StandardAutoresponderRecommendationProductEntity>();
        public List<StandardAutoresponderColumnEntity> StandardAutoreponderColumns { get; set; } = new List<StandardAutoresponderColumnEntity>();
        public List<StandardAutoresponderTemplateEntity> StandardAutoresponderTemplates { get; set; } = new List<StandardAutoresponderTemplateEntity>();
        public List<MarketplaceConnectionEntity> MarketplaceConnections { get; set;} = new List<MarketplaceConnectionEntity>();
        public List<StandardAutoresponderBlackListEntity> StandardAutoresponderBlackLists { get; set;} = new List<StandardAutoresponderBlackListEntity>();
        public List<UserNotificationEntity> Notifications { get; set; } = new List<UserNotificationEntity>();
    }
}
