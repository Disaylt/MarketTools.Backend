using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Requests.MarketplaceConnections.Command.SellerOpenApi;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.WB.Connections.Seller
{
    public class RefreshTokenOpenApiBody : IHasMap
    {
        public int Id { get; set; }

        [MaxLength(1000, ErrorMessage = "Длинна токена не может превышать 1000 символов.")]
        public string Token { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RefreshTokenOpenApiBody, OpenApiRefreshTokenCommand>();
        }
    }
}
