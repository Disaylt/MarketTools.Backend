using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class AddRatingQuery
    {
        [Range(1,5, ErrorMessage = "Оценка должна быть в диапозоне от 1 до 5")]
        public int Rating { get; set; }
        
        public int ConnectionId { get; set; }
    }
}
