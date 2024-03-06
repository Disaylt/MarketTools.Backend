using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Requests.MarketplaceConnections.Command.Ozon.Seller.Account;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.MarketplaceConnections.Ozon.Seller.Account
{
    public class UpdateRefreshTokenModel : IHasMap
    {
        [MaxLength(1000, ErrorMessage = "Длинна токена не может превышать 1000 символов.")]
        public string Token { get; set; } = string.Empty;
        public int ConnectionId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateRefreshTokenModel, UpdateRefreshTokenSellerAccountCommand>();
        }
    }
}
