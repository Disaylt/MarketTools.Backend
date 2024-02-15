using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard.Template
{
    public class ArticleVm : IHasMap
    {
        public int Id { get; set; }
        public required string Value { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderTemplateArticleEntity, ArticleVm>();
        }
    }
}
