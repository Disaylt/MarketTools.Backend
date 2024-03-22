using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Feedbacks
{
    public class FeedbackDto
    {
        public required string Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string? Answer { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Grade { get; set; }
        public ProductDetails ProductDetails { get; set; } = new ProductDetails();
    }

    public class ProductDetails
    {
        public string Article { get; set; } = string.Empty;
        public string SellerArticle { get; set; } = string.Empty;
        public string ProductName { get; set; } = "-";
    }
}
