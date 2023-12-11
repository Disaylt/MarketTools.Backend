﻿using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Commands.Create;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Autoreponder
{
    public class RecommendationProductCreateDto : RecommendationProductDetails, IHasMap
    {
        
        public MarketplaceName MarketplaceName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RecommendationProductCreateDto, CreateCommand>();
        }
    }
}
