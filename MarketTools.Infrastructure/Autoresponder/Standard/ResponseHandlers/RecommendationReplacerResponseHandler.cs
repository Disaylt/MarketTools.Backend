using DocumentFormat.OpenXml.InkML;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Application.Utilities.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Autoresponder.Standard.ResponseHandlers
{
    internal class RecommendationReplacerResponseHandler
        : AutoresponderResponseHandler<ResponseDetails, ResponseDetails>
    {
        private static Random _random = new Random();

        public override ResponseDetails Handle(ResponseDetails body)
        {
            if (body.ColumnType != AutoresponderColumnType.Recommendation)
            {
                return body;
            }

            ReportBuilder.AppendLine("- Производится выбор рекомендации и её вставка в текст.");

            StandardAutoresponderRecommendationProductEntity recommendation = SelectRandomRecommendation();
            body.Text = ReplaceRecommendationBindWords(body.Text, recommendation);

            return body;
        }

        private string ReplaceRecommendationBindWords(string text, StandardAutoresponderRecommendationProductEntity recommendation)
        {
            return text.Replace(StandardAutoresponderBindKeys.RecommendationArticle, recommendation.RecommendationArticle)
                .Replace(StandardAutoresponderBindKeys.RecommendationName, recommendation.RecommendationProductName)
                .Replace(StandardAutoresponderBindKeys.BuyArticle, recommendation.FeedbackArticle)
                .Replace(StandardAutoresponderBindKeys.BuyName, recommendation.FeedbackProductName);
        }

        private StandardAutoresponderRecommendationProductEntity SelectRandomRecommendation()
        {
            IEnumerable<StandardAutoresponderRecommendationProductEntity> products = Context.RecommendationProducts
                .Where(x => x.FeedbackArticle == Request.Article);

            int countProducts = products.Count();
            int index = _random.Next(0, countProducts);

            return products.ElementAtOrDefault(index)
                ?? throw new Exception($"Не удалось найти рекомендацию для артикула '{Request.Article}'");
        }
    }
}
