using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class RecommendationProductDetails
    {
        [MaxLength(25, ErrorMessage = "Превышена максимальная длинна артикула купленного продукта")]
        [Required(ErrorMessage = "Введите артикул")]
        public string FeedbackArticle { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "Превышена максимальная длинна названия купленного продукта")]
        public string? FeedbackProductName { get; set; }

        [MaxLength(25, ErrorMessage = "Превышена максимальная длинна артикула рекомендуеммого продукта")]
        public string? RecommendationArticle { get; set; }

        [MaxLength(100, ErrorMessage = "Превышена максимальная длинна названия рекомендуеммого продукта")]
        public string? RecommendationProductName { get; set; }
    }
}
