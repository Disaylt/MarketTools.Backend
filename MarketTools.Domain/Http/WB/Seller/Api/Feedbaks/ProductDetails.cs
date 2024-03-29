﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Http.WB.Seller.Api.Feedbaks
{
    public class ProductDetails
    {
        public int ImtId { get; set; }
        public int NmId { get; set; }
        public required string ProductName { get; set; }
        public required string SupplierArticle { get; set; }
        public required string SupplierName { get; set; }
        public required string BrandName { get; set; }
        public required string Size { get; set; }
    }
}
