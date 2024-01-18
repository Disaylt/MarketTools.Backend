using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Commands.Update;
using MarketTools.Application.Common.Mappings;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
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
