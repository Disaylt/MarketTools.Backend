using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Requests.MarketplaceConnections.Command.Ozon.Seller.Account;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.MarketplaceConnections.Ozon.Seller.Account
{
    public class NewOzonConnectionModel : ConnectionBaseModel, IHasMap
    {
        [MaxLength(1000, ErrorMessage = "Длинна токена не может превышать 1000 символов.")]
        public string RefreshToken { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "Id не модет превышать 100 символов.")]
        public string SellerId { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewOzonConnectionModel, AddOzonSellerAccountCommand>();
        }
    }
}
