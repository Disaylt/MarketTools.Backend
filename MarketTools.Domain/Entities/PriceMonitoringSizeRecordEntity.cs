using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class PriceMonitoringSizeRecordEntity : BaseEntity
    {
        [Required]
        public string SizeName { get; set; } = null!;

        public double NewSellerPrice { get; set; }
        public double NewSellerDicsountPrice { get; set; }
        public int NewSellerDiscount { get; set; }
        public double NewBuyerDiscountPrice { get; set; }
        public int NewBuyerDiscount { get; set; }

        public double OldSellerPrice { get; set; }
        public double OldSellerDicsountPrice { get; set; }
        public int OldSellerDiscount { get; set; }
        public double OldBuyerDiscountPrice { get; set; }
        public int OldBuyerDiscount { get; set; }

        public int ProductRecordId { get; set; }
        public PriceMonitoringProductRecordEntity ProductRecord { get; set; } = null!;
    }
}
