using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Cells.Commands.Update;
using MarketTools.Application.Common.Mappings;

namespace MarketTools.WebApi.Models.Api.Autoreponder
{
    public class CellUpdateDto : CellDto, IHasMap
    {
        public int Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CellUpdateDto, CellUpdateCommand>();
        }
    }
}
