using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class RecommendationProductUpdateDto : RecommendationProductDetails, IHasMap
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RecommendationProductUpdateDto, RecommendationProductUpdateCommand>();
        }
    }
}
