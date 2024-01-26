using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class RatingVm : IHasMap
    {
        public int Rating { get; set; }
        public IEnumerable<TemplateVm> Templates { get; set; } = Enumerable.Empty<TemplateVm>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderConnectionRatingEntity, RatingVm>();
        }
    }
}
