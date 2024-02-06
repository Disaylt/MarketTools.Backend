using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.Autoresponder.Standard.ResponseHandlers
{
    internal class ResponseTextValidationHandler
        : AutoresponderResponseHandler<string, string>
    {
        public ResponseTextValidationHandler(AutoresponderContext context, AutoresponderRequestModel request, StringBuilder reportBuilder) : base(context, request, reportBuilder)
        {
        }

        public override string Handle(string body)
        {
            body = body.Trim();

            if (string.IsNullOrEmpty(body))
            {
                throw new Exception("Собран пустой ответ");
            }

            if(body.Contains(StandardAutoresponderBindKeys.BuyName)
                || body.Contains(StandardAutoresponderBindKeys.BuyArticle)
                || body.Contains(StandardAutoresponderBindKeys.RecommendationArticle)
                || body.Contains(StandardAutoresponderBindKeys.RecommendationName))
            {
                throw new Exception("В ответе присутствуют ключи для замены на рекомендации");
            }

            if(body.Length >= 1000)
            {
                throw new Exception("Ответ не может превышать 1000 символов");
            }

            return body;
        }
    }
}
