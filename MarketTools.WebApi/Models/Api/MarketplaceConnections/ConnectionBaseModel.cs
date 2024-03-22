using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.MarketplaceConnections
{
    public class ConnectionBaseModel
    {
        [MaxLength(100, ErrorMessage = "Длинна названия не может превышать 100 символов.")]
        public string Name { get; set; } = null!;

        [MaxLength(300, ErrorMessage = "Длинна описания не может превышать 300 символов.")]
        public string? Description { get; set; }
    }
}
