using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Commands.Create
{
    public class CreateCommand : IRequest<StandardAutoresponderRecommendationProductEntity>, IHasMap
    {
        public required string FeedbackArticle { get; set; }
        public string? FeedbackProductName { get; set; }
        public string? RecommendationArticle { get; set; }
        public string? RecommendationProductName { get; set; }
        public MarketplaceName MarketplaceName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCommand, StandardAutoresponderRecommendationProductEntity>();
        }
    }
}
