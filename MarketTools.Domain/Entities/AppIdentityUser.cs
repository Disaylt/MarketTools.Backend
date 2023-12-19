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

        public List<AutoresponderStandardRecommendationProduct> AutoresponderRecommendationProducts { get; set; } = new List<AutoresponderStandardRecommendationProduct>();
        public List<AutoresponderStandardColumn> AutoreponderColumns { get; set; } = new List<AutoresponderStandardColumn>();
        public List<AutoresponderStandardTemplate> AutoresponderTemplates { get; set; } = new List<AutoresponderStandardTemplate>();
        public List<SellerConnection> SellerConnections { get; set;} = new List<SellerConnection>();
        public List<AutoresponderStandardBlackList> AutoresponderBlackLists { get; set;} = new List<AutoresponderStandardBlackList>();
    }
}
