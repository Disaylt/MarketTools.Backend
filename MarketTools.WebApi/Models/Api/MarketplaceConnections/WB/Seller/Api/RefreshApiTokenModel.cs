using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Requests.MarketplaceConnections.Command.WB.Seller.Api;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.MarketplaceConnections.WB.Seller.Api
{
    public class RefreshApiTokenModel : IHasMap
    {
        [MaxLength(1000, ErrorMessage = "Длинна токена не может превышать 1000 символов.")]
        public string Token { get; set; } = string.Empty;
        public int ConnectionId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RefreshApiTokenModel, UpdateTokenSellerApiCommand>();
        }
    }
}
