﻿using MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Models;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.RecommendationProducts.Commands.Update
{
    public class UpdateCommand : IRequest
    {
        public int Id { get; set; }
        public required string FeedbackArticle { get; set; }
        public string? FeedbackProductName { get; set; }
        public string? RecommendationArticle { get; set; }
        public string? RecommendationProductName { get; set; }
    }
}
