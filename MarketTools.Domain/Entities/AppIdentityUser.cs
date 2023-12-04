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

        public List<AutoresponderRecommendationProduct> AutoresponderRecommendationProducts { get; set; } = new List<AutoresponderRecommendationProduct>();
    }
}
