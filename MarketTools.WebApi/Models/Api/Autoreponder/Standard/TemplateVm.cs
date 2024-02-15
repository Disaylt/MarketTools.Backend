using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class TemplateVm : IHasMap
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? BlackListId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderTemplateEntity, TemplateVm>();
        }
    }
}
