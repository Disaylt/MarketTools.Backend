using AutoMapper;
using MarketTools.Application.Common.Mappings;
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
