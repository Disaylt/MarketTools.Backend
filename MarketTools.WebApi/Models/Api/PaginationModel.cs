using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api
{
    public class PaginationModel
    {
        [Range(1, 100, ErrorMessage = "Диапазон получения объектов от 1 до 100.")]
        public virtual int Take { get; set; }
        public virtual int Skip { get; set; }
    }
}
