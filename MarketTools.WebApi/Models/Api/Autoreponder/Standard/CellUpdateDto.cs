using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Requests.Autoresponder.Standard.Cells.Commands;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
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
