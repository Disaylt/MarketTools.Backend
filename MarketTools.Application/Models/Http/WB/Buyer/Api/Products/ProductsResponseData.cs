using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Http.WB.Buyer.Api.Products
{
    public class WbBuyerApiProductsResponseData
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }

    public class Price
    {
        [JsonPropertyName("basic")]
        public int Basic { get; set; }
        public double BasicReal
        {
            get
            {
                return Basic / 100d;
            }
        }

        [JsonPropertyName("product")]
        public int Product { get; set; }
        public double ProductReal
        {
            get
            {
                return Product / 100d;
            }
        }

        [JsonPropertyName("total")]
        public int Total { get; set; }
        public double TotalReal
        {
            get
            {
                return Total / 100d;
            }
        }

        [JsonPropertyName("logistics")]
        public int Logistics { get; set; }
        public double LogisticsReal
        {
            get
            {
                return Logistics / 100d;
            }
        }

        [JsonPropertyName("return")]
        public int Return { get; set; }

    }

    public class Size
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("origName")]
        public string OrigName { get; set; } = string.Empty;

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("optionId")]
        public int OptionId { get; set; }

        [JsonPropertyName("stocks")]
        public List<Stock> Stocks { get; set; } = new List<Stock>();

        [JsonPropertyName("time1")]
        public int Time1 { get; set; }

        [JsonPropertyName("time2")]
        public int Time2 { get; set; }

        [JsonPropertyName("wh")]
        public int Wh { get; set; }

        [JsonPropertyName("dtype")]
        public int Dtype { get; set; }

        [JsonPropertyName("price")]
        public Price Price { get; set; } = new Price();

        [JsonPropertyName("saleConditions")]
        public int SaleConditions { get; set; }

        [JsonPropertyName("payload")]
        public string Payload { get; set; } = string.Empty;
    }

    public class Stock
    {
        [JsonPropertyName("wh")]
        public int Wh { get; set; }

        [JsonPropertyName("dtype")]
        public int Dtype { get; set; }

        [JsonPropertyName("qty")]
        public int Qty { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("time1")]
        public int Time1 { get; set; }

        [JsonPropertyName("time2")]
        public int Time2 { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("root")]
        public int Root { get; set; }

        [JsonPropertyName("kindId")]
        public int KindId { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; } = string.Empty;

        [JsonPropertyName("brandId")]
        public int BrandId { get; set; }

        [JsonPropertyName("siteBrandId")]
        public int SiteBrandId { get; set; }

        [JsonPropertyName("colors")]
        public List<Color> Colors { get; set; } = new List<Color>();

        [JsonPropertyName("subjectId")]
        public int SubjectId { get; set; }

        [JsonPropertyName("subjectParentId")]
        public int SubjectParentId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("supplier")]
        public string Supplier { get; set; } = string.Empty;

        [JsonPropertyName("supplierId")]
        public int SupplierId { get; set; }

        [JsonPropertyName("supplierRating")]
        public double SupplierRating { get; set; }

        [JsonPropertyName("supplierFlags")]
        public int SupplierFlags { get; set; }

        [JsonPropertyName("pics")]
        public int Pics { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("reviewRating")]
        public double ReviewRating { get; set; }

        [JsonPropertyName("feedbacks")]
        public int Feedbacks { get; set; }

        [JsonPropertyName("volume")]
        public int Volume { get; set; }

        [JsonPropertyName("viewFlags")]
        public int ViewFlags { get; set; }

        [JsonPropertyName("promotions")]
        public List<int> Promotions { get; set; } = new List<int>();

        [JsonPropertyName("sizes")]
        public List<Size> Sizes { get; set; } = new List<Size>();

        [JsonPropertyName("time1")]
        public int Time1 { get; set; }

        [JsonPropertyName("time2")]
        public int Time2 { get; set; }

        [JsonPropertyName("wh")]
        public int Wh { get; set; }

        [JsonPropertyName("dtype")]
        public int Dtype { get; set; }
    }

    public class Color
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } =  string.Empty;

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
