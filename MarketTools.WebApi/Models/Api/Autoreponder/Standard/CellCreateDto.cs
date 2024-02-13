using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Cells.Commands.Create;
using MarketTools.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class CellCreateDto : CellDto, IHasMap
    {
        public int ColumnId { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<CellCreateDto, CellCreateCommand>();
        }
    }
}
