using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.Autoresponder.Standard.ResponseHandlers
{
    internal class FilterEmptyColumnTypeResponseHandler
        : AutoresponderResponseHandler<IEnumerable<TemplateDetails>, IEnumerable<TemplateDetails>>
    {
        public override IEnumerable<TemplateDetails> Handle(IEnumerable<TemplateDetails> body)
        {
            ReportBuilder.AppendLine($"- Проверка сущетсвования колонок выбранного типа ответов.");

            List<TemplateDetails> filterTemplate = new List<TemplateDetails>();

            foreach (TemplateDetails item in body)
            {
                if (ContainsTypeColumns(item))
                {
                    ReportBuilder.AppendLine($"* '{item.Template.Name}' содержит колоноки выбранного типа.");
                    filterTemplate.Add(item);
                    continue;
                }

                ReportBuilder.AppendLine($"* '{item.Template.Name}' не содержит колонок выбранного типа.");
            }

            if(filterTemplate.Count == 0)
            {
                throw new Exception("После проверки колонок список доступных шаблонов пуст.");
            }

            return body;
        }

        private bool ContainsTypeColumns(TemplateDetails responseBuildDetails)
        {
            return responseBuildDetails.Template
                .BindPositions
                .Select(x => x.Column)
                .Any(x => x.Type == responseBuildDetails.ColumnType);
        }
    }
}
