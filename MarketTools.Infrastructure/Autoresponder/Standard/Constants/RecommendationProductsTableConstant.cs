using MarketTools.Infrastructure.Autoresponder.Standard.Enums;
using MarketTools.Infrastructure.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Autoresponder.Standard.Constants
{
    internal class RecommendationProductsTableConstant
    {
        public static IEnumerable<ColumnDetailsDto> Value => _value;

        private static readonly IEnumerable<ColumnDetailsDto> _value = new List<ColumnDetailsDto>
        {
            new ColumnDetailsDto
            {
                Position = (int)RecommendationProductsColumns.FeedbackArticle,
                Name = "Артикул",
                Width = 20
            },
            new ColumnDetailsDto
            {
                Position = (int)RecommendationProductsColumns.FeedbackProductName,
                Name = "Название",
                Width = 60
            },
            new ColumnDetailsDto
            {
                Position = (int)RecommendationProductsColumns.RecommendationArticle,
                Name = "Рек. артикул",
                Width = 20
            },
            new ColumnDetailsDto
            {
                Position = (int)RecommendationProductsColumns.RecommendationProductName,
                Name = "Рек. название",
                Width = 60
            }
        };
    }
}
