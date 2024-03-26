using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Http.WB.Seller.Api.Prices
{
    public class PriceProductsResponseData
    {
        public List<PriceProducs> ListGoods { get; set;  } = new List<PriceProducs>();
    }

    public class PriceProducs
    {
        [JsonPropertyName("nmID")]
        public int Article { get; set; }

        public string VendorCode { get; set; } = "-";
        public List<Size> Sizes { get; set; } = new List<Size>();
        public string CurrencyIsoCode4217 { get; set; } = "";
        public int Discount { get; set; }
        public bool EditableSizePrice { get; set; }
    }

    public class Size
    {
        public int SizeId { get; set; }
        public int Price { get; set; }
        public double DiscountedPrice { get; set; }
        public string TechSizeName { get; set; } = "Неизвестно";
    }
}
