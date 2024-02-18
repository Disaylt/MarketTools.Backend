using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Application.Utilities.Autoresponder.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Autoresponder.Standard.ResponseHandlers
{
    internal class ResponseTextValidationHandler
        : AutoresponderResponseHandler<ResponseDetails, string>
    {
        public override string Handle(ResponseDetails body)
        {
            string responseText = body.Text.Trim();

            if (string.IsNullOrEmpty(responseText))
            {
                throw new Exception("Собран пустой ответ");
            }

            if (responseText.Contains(StandardAutoresponderBindKeys.BuyName)
                || responseText.Contains(StandardAutoresponderBindKeys.BuyArticle)
                || responseText.Contains(StandardAutoresponderBindKeys.RecommendationArticle)
                || responseText.Contains(StandardAutoresponderBindKeys.RecommendationName))
            {
                throw new Exception("В ответе присутствуют ключи для замены на рекомендации");
            }

            if (responseText.Length >= 1000)
            {
                throw new Exception("Ответ не может превышать 1000 символов");
            }

            return responseText;
        }
    }
}
