using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AutoresponderRecommendationProduct : BaseEntity
    {
        [MaxLength(25, ErrorMessage = "Превышена максимальная длинна артикула купленного продукта")]
        public string FeedbackArticle { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "Превышена максимальная длинна названия купленного продукта")]
        public string? FeedbackProductName { get; set; }

        [MaxLength(25, ErrorMessage = "Превышена максимальная длинна артикула рекомендуеммого продукта")]
        public string? RecommendationArticle { get; set; }

        [MaxLength(100, ErrorMessage = "Превышена максимальная длинна названия рекомендуеммого продукта")]
        public string? RecommendationProductName { get; set; }
        public MarketplaceName MarketplaceName { get; set; }

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;
    }
}
