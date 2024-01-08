using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.Add;
using MarketTools.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard.Template
{
    public class ArticleCreateDto : IHasMap
    {
        public int TemplateId { get; set; }

        [Required(ErrorMessage = "Введите артикул.")]
        [MaxLength(100, ErrorMessage = "Максимальная длинна 100 символов.")]
        public required string Article { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ArticleCreateDto, ArticleAddCommand>();
        }
    }
}
