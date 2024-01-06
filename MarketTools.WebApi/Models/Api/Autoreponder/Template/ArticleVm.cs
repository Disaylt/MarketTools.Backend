using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Template
{
    public class ArticleVm : IHasMap
    {
        public int Id { get; set; }
        public required string Article { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderTemplateArticleEntity, ArticleVm>();
        }
    }
}
