using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Application.Requests.MarketplaceConnections.OpenApi.Command.Add;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.WB.Connections.Seller
{
    public class NewOpenApiBody : IHasMap
    {
        [MaxLength(100, ErrorMessage = "Длинна названия не может превышать 100 символов.")]
        public string Name { get; set; } = null!;

        [MaxLength(300, ErrorMessage = "Длинна описания не может превышать 300 символов.")]
        public string? Description { get; set; }

        [MaxLength(1000, ErrorMessage = "Длинна токена не может превышать 1000 символов.")]
        public string Token { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewOpenApiBody, SellerOpenApiAddCommand>();
        }
    }
}
