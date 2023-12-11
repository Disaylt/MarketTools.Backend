using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Commands.Update;
using MarketTools.Application.Common.Mappings;

namespace MarketTools.WebApi.Models.Autoreponder
{
    public class RecommendationProductUpdateDto : RecommendationProductDetails, IHasMap
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RecommendationProductUpdateDto, UpdateCommand>();
        }
    }
}
