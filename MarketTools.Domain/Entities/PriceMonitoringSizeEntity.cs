using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class PriceMonitoringSizeEntity : BaseEntity
    {
        [Required]
        public string SizeName { get; set; } = null!;

        public double SellerPrice { get; set; }
        public double SellerDicsountPrice { get; set; }
        public int SellerDiscount { get; set; }
        public double BuyerDiscountPrice { get; set; }
        public int BuyerDiscount { get; set; }

        public int ProductId { get; set; }
        public PriceMonotoringProductEntity Product { get; set; } = null!;
    }
}
