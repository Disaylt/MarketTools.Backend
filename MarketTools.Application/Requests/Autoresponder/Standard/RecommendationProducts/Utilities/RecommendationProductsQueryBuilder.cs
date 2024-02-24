﻿using MarketTools.Application.Common.Builders.Requests;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Utilities
{
    internal class RecommendationProductsQueryBuilder : BaseQueryBuilder<StandardAutoresponderRecommendationProductEntity>
    {
        public RecommendationProductsQueryBuilder(IRepository<StandardAutoresponderRecommendationProductEntity> repostitory)
            : base(repostitory.GetAsQueryable())
        {
        }

        public RecommendationProductsQueryBuilder SetMarketplace(MarketplaceName? marketplaceName)
        {
            if (marketplaceName.HasValue)
            {
                Query = Query.Where(x => x.MarketplaceName == marketplaceName);
            }

            return this;
        }

        public RecommendationProductsQueryBuilder SetArticle(string? article)
        {
            if (string.IsNullOrEmpty(article) == false)
            {
                Query = Query.Where(x => x.FeedbackArticle == article);
            }

            return this;
        }
    }
}