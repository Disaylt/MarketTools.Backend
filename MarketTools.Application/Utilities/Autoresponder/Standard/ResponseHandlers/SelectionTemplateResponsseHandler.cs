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
        : AutoresponderResponseHandler<IEnumerable<ResponseBuildDetails>, ResponseBuildDetails>
    {
        private readonly static Random _random = new Random();

        public SelectionTemplateResponsseHandler(AutoresponderContext context, AutoresponderRequestModel request, StringBuilder reportBuilder) : base(context, request, reportBuilder)
        {
        }

        public override ResponseBuildDetails Handle(IEnumerable<ResponseBuildDetails> body)
        {
            ReportBuilder.AppendLine($"- Выбираем случайный шааблон для ответов (Предочтительны шаблоны с артикулами)");

            List<ResponseBuildDetails> responseBuildDetailsWithArticle = FilterTemplates(body, true);
            ResponseBuildDetails? selectionBuilderWithArticle = SelectRandomOrDefault(responseBuildDetailsWithArticle);
            if(selectionBuilderWithArticle != null)
            {
                ReportBuilder.AppendLine($"* Выбран шаблон ${selectionBuilderWithArticle.Template.Name} с установленным артикулом.");

                return selectionBuilderWithArticle;
            }

            List<ResponseBuildDetails> responseBuildDetailsWithoutArticle = FilterTemplates(body, false);
            ResponseBuildDetails? selectionBuilderWithoutArticle = SelectRandomOrDefault(responseBuildDetailsWithoutArticle);
            if (selectionBuilderWithoutArticle != null)
            {
                ReportBuilder.AppendLine($"* Выбран шаблон ${selectionBuilderWithoutArticle.Template.Name} без установленных артикулов.");

                return selectionBuilderWithoutArticle;
            }

            throw new Exception("Не удалось выбрать шаблон.");
        }

        private List<ResponseBuildDetails> FilterTemplates(IEnumerable<ResponseBuildDetails> body, bool withArticleFilter)
        {
            return body
                .Where(x => x.Template.Articles.Any() == withArticleFilter)
                .ToList();
        }

        private ResponseBuildDetails? SelectRandomOrDefault(IEnumerable<ResponseBuildDetails> value)
        {
            int count = value.Count();
            int index = _random.Next(0, count);

            return value.ElementAtOrDefault(index);
        }
    }
}
