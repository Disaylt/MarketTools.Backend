using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard.BlackList
{
    public class BanWordVm : IHasMap
    {
        public int Id { get; set; } 
        public string Value { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderBanWordEntity, BanWordVm>();
        }
    }
}
