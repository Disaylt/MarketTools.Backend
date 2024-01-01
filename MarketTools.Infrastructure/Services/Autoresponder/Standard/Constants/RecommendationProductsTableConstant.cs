using MarketTools.Infrastructure.Excel;
using MarketTools.Infrastructure.Services.Autoresponder.Standard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Services.Autoresponder.Standard.Constants
{
    internal class RecommendationProductsTableConstant
    {
        public  static IEnumerable<ColumnDetailsDto> Value => _value;

        private static readonly IEnumerable<ColumnDetailsDto> _value = new List<ColumnDetailsDto>
        {
            new ColumnDetailsDto
            {
                Position = (int)RecommendationProductsColumns.FeedbackArticle,
                Name = "Артикул",
                Width = 100
            },
            new ColumnDetailsDto
            {
                Position = (int)RecommendationProductsColumns.FeedbackArticle,
                Name = "Название",
                Width = 300
            },
            new ColumnDetailsDto
            {
                Position = (int)RecommendationProductsColumns.FeedbackArticle,
                Name = "Рек. артикул",
                Width = 100
            },
            new ColumnDetailsDto
            {
                Position = (int)RecommendationProductsColumns.FeedbackArticle,
                Name = "Рек. название",
                Width = 300
            }
        };
    }
}
