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

        public List<StandardAutoresponderRecommendationProduct> StandardAutoresponderRecommendationProducts { get; set; } = new List<StandardAutoresponderRecommendationProduct>();
        public List<StandardAutoresponderColumn> StandardAutoreponderColumns { get; set; } = new List<StandardAutoresponderColumn>();
        public List<StandardAutoresponderTemplate> StandardAutoresponderTemplates { get; set; } = new List<StandardAutoresponderTemplate>();
        public List<SellerConnection> SellerConnections { get; set;} = new List<SellerConnection>();
        public List<StandardAutoresponderBlackList> StandardAutoresponderBlackLists { get; set;} = new List<StandardAutoresponderBlackList>();
    }
}
