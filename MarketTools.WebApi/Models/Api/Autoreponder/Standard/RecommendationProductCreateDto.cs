using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Commands.Create;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class RecommendationProductCreateDto : RecommendationProductDetails, IHasMap
    {

        public MarketplaceName MarketplaceName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RecommendationProductCreateDto, RecommendationProductCreateCommand>();
        }
    }
}
