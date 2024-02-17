using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.Autoresponder.Standard.ResponseHandlers
{
    public class SelectionTemplatesResponseHandler : AutoresponderResponseHandler<StandardAutoresponderConnectionRatingEntity, IEnumerable<StandardAutoresponderTemplateEntity>>
    {
        public override IEnumerable<StandardAutoresponderTemplateEntity> Handle(StandardAutoresponderConnectionRatingEntity body)
        {
            IEnumerable<StandardAutoresponderTemplateEntity> templates = FindTemplates(body);

            if (templates.Any() == false)
            {
                throw new Exception("В списке шаблонов нет ни одного подходящего для ответа шаблона.");
            }

            ReportBuilder.AppendLine($"- В списке найдено '{templates.Count()}' подходящих шаблонов для создания ответа.");

            return templates;
        }

        private IEnumerable<StandardAutoresponderTemplateEntity> FindTemplates(StandardAutoresponderConnectionRatingEntity body)
        {
            return body.Templates
                .Where(template => template.Articles.Count == 0 
                    || template.Articles.Any(article => article.Value == Request.Article));
        }
    }
}
