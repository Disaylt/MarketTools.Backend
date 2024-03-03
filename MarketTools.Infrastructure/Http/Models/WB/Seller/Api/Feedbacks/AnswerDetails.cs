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
    internal class AnswerDetails : IHasMap
    {
        public string? Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AnswerDetails, AnswerDetailsDto>();
        }
    }
}
