using MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Models;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.RecommendationProducts.Utilities
{
    public class DetailsBuilder
    {
        private readonly RangeCommand _rangeCommand;

        public DetailsBuilder(RangeCommand rangeCommand)
        {
            _rangeCommand = rangeCommand;
        }

        public DetailsBuilder AddMainDetails(string userId, MarketplaceName marketplaceName)
        {
            foreach (StandardAutoresponderRecommendationProductEntity product in _rangeCommand.Products)
            {
                product.MarketplaceName = marketplaceName;
                product.UserId = userId;
            }

            return this;
        }

        public IEnumerable<StandardAutoresponderRecommendationProductEntity> Build()
        {
            return _rangeCommand.Products;
        }
    }
}
