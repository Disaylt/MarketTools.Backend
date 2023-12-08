using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Cells.Commands.Create;
using MarketTools.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Autoreponder
{
    public class CellCreateOrUpdateDto : IHasMap
    {
        [MaxLength(1000, ErrorMessage = "Превышен лимит в 1000 символов")]
        public required string Value { get; set; }
        public int ColumnId { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<CellCreateOrUpdateDto, CreateCellCommand>();
        }
    }
}
