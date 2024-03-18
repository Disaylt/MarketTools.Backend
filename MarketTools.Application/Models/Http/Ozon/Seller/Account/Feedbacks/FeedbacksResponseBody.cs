using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MarketTools.Application.Models.Http.Ozon.Seller.Account.Feedbacks
{
    public class FeedbacksResponseBody
    {
        [JsonPropertyName("result")]
        public List<Feedback> Result { get; set; } = new List<Feedback>();

        [JsonPropertyName("pagination_last_timestamp")]
        public string? PaginationLastTimestamp { get; set; }

        [JsonPropertyName("pagination_last_uuid")]
        public string? PaginationLastUuid { get; set; }

        [JsonPropertyName("counters")]
        public Counters? Counters { get; set; }

        [JsonPropertyName("hasNext")]
        public bool HasNext { get; set; }

        [JsonPropertyName("tariff")]
        public string Tariff { get; set; } = "-";
    }

    public class BrandInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class CompanyInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class Counters
    {
    }

    public class Product
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = "Неизвестно";

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("offer_id")]
        public string OfferId { get; set; } = string.Empty;

        [JsonPropertyName("company_info")]
        public CompanyInfo CompanyInfo { get; set; } = new CompanyInfo();

        [JsonPropertyName("brand_info")]
        public BrandInfo BrandInfo { get; set; } = new BrandInfo();

        [JsonPropertyName("cover_image")]
        public string CoverImage { get; set; } = string.Empty;
    }

    public class Feedback
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("sku")]
        public string Sku { get; set; } = string.Empty;

        [JsonPropertyName("text")]
        public Text Text { get; set; } = new Text();

        [JsonPropertyName("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("interaction_status")]
        public string InteractionStatus { get; set; } = = string.Empty;

        [JsonPropertyName("comments_amount")]
        public int CommentsAmount { get; set; }

        [JsonPropertyName("likes_amount")]
        public int LikesAmount { get; set; }

        [JsonPropertyName("dislikes_amount")]
        public int DislikesAmount { get; set; }

        [JsonPropertyName("author_name")]
        public string AuthorName { get; set; } = = string.Empty;

        [JsonPropertyName("photos_count")]
        public int PhotosCount { get; set; }

        [JsonPropertyName("videos_count")]
        public int VideosCount { get; set; }

        [JsonPropertyName("comments_count")]
        public int CommentsCount { get; set; }

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; } = string.Empty;

        [JsonPropertyName("product")]
        public Product Product { get; set; } = new Product();

        [JsonPropertyName("orderDeliveryType")]
        public string OrderDeliveryType { get; set; } = string.Empty;

        [JsonPropertyName("orderDeliveryTypeMessage")]
        public object? OrderDeliveryTypeMessage { get; set; }

        [JsonPropertyName("is_pinned")]
        public bool IsPinned { get; set; }
    }

    public class Text
    {
        [JsonPropertyName("positive")]
        public string Positive { get; set; } = string.Empty;

        [JsonPropertyName("negative")]
        public string Negative { get; set; } = string.Empty;

        [JsonPropertyName("comment")]
        public string Comment { get; set; } = string.Empty;
    }
}
