using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;

namespace MarketTools.WebApi.Models.Api.Autoreponder
{
    public class RecommendationProductVm : IHasMap
    {
        public int Id { get; set; }
        public required string FeedbackArticle { get; set; }
        public string? FeedbackProductName { get; set; }
        public string? RecommendationArticle { get; set; }
        public string? RecommendationProductName { get; set; }
        public MarketplaceName MarketplaceName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderRecommendationProduct, RecommendationProductVm>();
        }
    }
}
