using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Identity
{
    public class UserVm : IHasMap
    {
        public required string Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public DateTime CreateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AppIdentityUser, UserVm>();
        }
    }
}
