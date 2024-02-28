using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Http.WB.Seller
{
    public class FeedbackDto : IHasMap
    {
        public required string Id { get; set; }
        public AnswerDetailsDto? Answer { get; set; }
        public string Text { get; set; } = string.Empty;
        public required ProductDetailsDto ProductDetails { get; set; }
        public int ProductValuation { get; set; }
        public DateTime CreatedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FeedbackDetails, FeedbackDto>();
        }
    }

    public class AnswerDetailsDto : IHasMap
    {
        public string? Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AnswerDetails, AnswerDetailsDto>();
        }
    }

    public class ProductDetailsDto : IHasMap
    {
        public int ImtId { get; set; }
        public int NmId { get; set; }
        public required string ProductName { get; set; }
        public required string SupplierArticle { get; set; }
        public required string SupplierName { get; set; }
        public required string BrandName { get; set; }
        public required string Size { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductDetails, ProductDetailsDto>();
        }
    }
}
