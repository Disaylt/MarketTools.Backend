using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Commands.Add;
using MarketTools.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Autoreponder
{
    public class TemplateCreateDto : IHasMap
    {
        [Required(ErrorMessage = "Введите название.")]
        [MaxLength(100, ErrorMessage = "Максимальная длинна названия 100 символов.")]
        public required string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TemplateCreateDto, AddCommand>();
        }
    }
}
