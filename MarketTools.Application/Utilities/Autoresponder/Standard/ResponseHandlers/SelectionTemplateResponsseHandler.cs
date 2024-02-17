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
    internal class SelectionTemplateResponsseHandler
        : AutoresponderResponseHandler<IEnumerable<TemplateDetails>, TemplateDetails>
    {
        private readonly static Random _random = new Random();

        public override TemplateDetails Handle(IEnumerable<TemplateDetails> body)
        {
            ReportBuilder.AppendLine($"- Выбираем случайный шаблон для ответов (Предочтительны шаблоны с артикулами)");

            TemplateDetails? selectionBuilderWithArticle = SelectRandomBuilder(body, true);
            if(selectionBuilderWithArticle != null)
            {
                ReportBuilder.AppendLine($"* Выбран шаблон '{selectionBuilderWithArticle.Template.Name}' с установленным артикулом.");

                return selectionBuilderWithArticle;
            }

            TemplateDetails? selectionBuilderWithoutArticle = SelectRandomBuilder(body, false);
            if (selectionBuilderWithoutArticle != null)
            {
                ReportBuilder.AppendLine($"* Выбран шаблон '{selectionBuilderWithoutArticle.Template.Name}' без установленных артикулов.");

                return selectionBuilderWithoutArticle;
            }

            throw new Exception("Не удалось выбрать шаблон.");
        }

        private TemplateDetails? SelectRandomBuilder(IEnumerable<TemplateDetails> builders, bool withArticleFilter)
        {
            IEnumerable<TemplateDetails> filterBuilders = builders
                .Where(x => x.Template.Articles.Any() == withArticleFilter);
            int num = filterBuilders.Count();
            int index = _random.Next(num);

            return filterBuilders.ElementAtOrDefault(index);
        }
    }
}
