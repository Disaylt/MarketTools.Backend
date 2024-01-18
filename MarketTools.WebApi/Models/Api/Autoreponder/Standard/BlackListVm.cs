using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class BlackListVm : IHasMap
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderBlackListEntity, BlackListVm>();
        }
    }
}
