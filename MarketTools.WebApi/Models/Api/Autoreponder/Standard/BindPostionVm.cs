using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class BindPostionVm : IHasMap
    {
        public int Position { get; set; }
        public int ColumnId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderBindPositionEntity, BindPostionVm>();
        }
    }
}
