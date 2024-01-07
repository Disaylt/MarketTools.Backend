using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Queries.GetRange;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Common;
using MarketTools.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Autoreponder
{
    public class RecommendationProductGetRangeDto : PaginationModel, IHasMap
    {
        [MaxLength(25, ErrorMessage = "Максимальная длинна 25 символов.")]
        public string? Article { get; set; }
        public MarketplaceName MarketplaceName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RecommendationProductGetRangeDto, RecommendationProductGetRangeQuery>()
                .ForMember(result => result.PageRequest, request => request.MapFrom(model => new PageRequest { Skip = model.Skip, Take = model.Take}));
        }
    }
}
