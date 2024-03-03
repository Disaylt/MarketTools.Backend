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
    internal class FeedbackDetails : IHasMap
    {
        public required string Id { get; set; }
        public AnswerDetails? Answer { get; set; }
        public string Text { get; set; } = string.Empty;
        public required ProductDetails ProductDetails { get; set; }
        public int ProductValuation { get; set; }
        public DateTime CreatedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FeedbackDetails, FeedbackDto>();
        }
    }
}
