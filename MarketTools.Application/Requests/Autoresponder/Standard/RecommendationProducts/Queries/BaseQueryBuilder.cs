using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Queries
{
    internal class BaseQueryBuilder
    {
        private IQueryable<StandardAutoresponderRecommendationProduct> _query;

        public BaseQueryBuilder(IRepository<StandardAutoresponderRecommendationProduct> repostitory) 
        {
            _query = repostitory.GetAsQueryable();
        }

        public BaseQueryBuilder SetMarketplace(MarketplaceName marketplaceName)
        {
            _query = _query.Where(x=> x.MarketplaceName == marketplaceName);

            return this;
        }

        public BaseQueryBuilder SetArticle(string? article)
        {
            if (string.IsNullOrEmpty(article) == false)
            {
                _query = _query.Where(x => x.FeedbackArticle == article);
            }

            return this;
        }

        public IQueryable<StandardAutoresponderRecommendationProduct> Build()
        {
            return _query;
        }
    }
}
