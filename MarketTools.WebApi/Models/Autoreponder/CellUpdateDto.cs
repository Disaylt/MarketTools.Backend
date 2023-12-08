using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Cells.Commands.Create;
using MarketTools.Application.Common.Mappings;

namespace MarketTools.WebApi.Models.Autoreponder
{
    public class CellUpdateDto : CellCreateDto, IHasMap
    {
        public int ColumnId { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<CellUpdateDto, CreateCellCommand>();
        }
    }
}
