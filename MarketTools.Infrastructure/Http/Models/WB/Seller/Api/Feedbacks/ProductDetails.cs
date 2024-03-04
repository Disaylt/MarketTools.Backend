using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Models.Http.WB.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Models.WB.Seller.Api.Feedbacls
{
    public class ProductDetails : IHasMap
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
