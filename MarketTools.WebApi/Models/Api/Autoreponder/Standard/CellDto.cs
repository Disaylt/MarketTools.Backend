using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class CellDto
    {
        [MaxLength(1000, ErrorMessage = "Превышен лимит в 1000 символов")]
        [Required(ErrorMessage = "Введите текст")]
        public required string Value { get; set; }
    }
}
