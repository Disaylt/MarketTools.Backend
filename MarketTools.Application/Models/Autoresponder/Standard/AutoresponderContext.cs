using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Autoresponder.Standard
{
    public class AutoresponderContext
    {
        public IEnumerable<StandardAutoresponderRecommendationProductEntity> RecommendationProducts { get; set; } 
            = Enumerable.Empty<StandardAutoresponderRecommendationProductEntity>(); 

        public StandardAutoresponderConnectionEntity Connection { get; set; } = new StandardAutoresponderConnectionEntity();
    }
}
