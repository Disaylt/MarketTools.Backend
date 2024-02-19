using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Commands;
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
