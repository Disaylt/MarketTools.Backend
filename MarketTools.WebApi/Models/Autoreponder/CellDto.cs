using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Autoreponder
{
    public class CellDto
    {
        [MaxLength(1000, ErrorMessage = "Превышен лимит в 1000 символов")]
        public required string Value { get; set; }
    }
}
