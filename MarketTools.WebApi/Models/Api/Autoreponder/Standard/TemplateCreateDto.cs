using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Commands;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class TemplateCreateDto : IHasMap
    {
        [Required(ErrorMessage = "Введите название.")]
        [MaxLength(100, ErrorMessage = "Максимальная длинна названия 100 символов.")]
        public required string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TemplateCreateDto, TemplateAddCommand>();
        }
    }
}
