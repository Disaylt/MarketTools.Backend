using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class CellVm : IHasMap
    {
        public int Id { get; set; }
        public required string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderCellEntity, CellVm>();
        }
    }
}
