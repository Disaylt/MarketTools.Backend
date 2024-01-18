using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.MarketplaceConnections
{
    public class MarketplaceConnectionVm : IHasMap
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MarketplaceConnectionEntity, MarketplaceConnectionVm>();
        }
    }
}
