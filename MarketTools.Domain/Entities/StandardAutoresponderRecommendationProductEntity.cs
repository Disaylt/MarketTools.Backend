using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderRecommendationProductEntity : BaseEntity
    {
        [MaxLength(25, ErrorMessage = "Превышена максимальная длинна артикула купленного продукта")]
        [Required(ErrorMessage = "Введите артикул")]
        public string FeedbackArticle { get; set; } = null!;

        [MaxLength(1000, ErrorMessage = "Превышена максимальная длинна названия купленного продукта")]
        public string? FeedbackProductName { get; set; }

        [MaxLength(25, ErrorMessage = "Превышена максимальная длинна артикула рекомендуеммого продукта")]
        public string? RecommendationArticle { get; set; }

        [MaxLength(1000, ErrorMessage = "Превышена максимальная длинна названия рекомендуеммого продукта")]
        public string? RecommendationProductName { get; set; }

        [Range(1, 999)]
        public MarketplaceName MarketplaceName { get; set; }

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;
    }
}
