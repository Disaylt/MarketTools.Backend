using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Api.MarketplaceConnections
{
    public class ServiceConnectionVm : IHasMap
    {
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderConnectionEntity, ServiceConnectionVm>();
        }
    }
}
