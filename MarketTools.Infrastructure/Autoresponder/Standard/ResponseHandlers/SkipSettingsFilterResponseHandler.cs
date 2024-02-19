using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Autoresponder.Standard.ResponseHandlers
{
    internal class SkipSettingsFilterResponseHandler
        : AutoresponderResponseHandler<IEnumerable<StandardAutoresponderTemplateEntity>, IEnumerable<StandardAutoresponderTemplateEntity>>
    {
        public override IEnumerable<StandardAutoresponderTemplateEntity> Handle(IEnumerable<StandardAutoresponderTemplateEntity> body)
        {
            ReportBuilder.AppendLine("- Проверка настроек шаблона.");

            List<StandardAutoresponderTemplateEntity> filterTemplates = new List<StandardAutoresponderTemplateEntity>();

            foreach (StandardAutoresponderTemplateEntity template in body)
            {
                if (IsSkip(template))
                {
                    continue;
                }

                filterTemplates.Add(template);
            }

            if (filterTemplates.Count == 0)
            {
                throw new Exception("Ни один шаблон не прошел проверку настроек.");
            }

            return filterTemplates;
        }

        private bool IsSkip(StandardAutoresponderTemplateEntity template)
        {
            if (template.Settings.IsSkipEmptyFeedbacks && string.IsNullOrEmpty(Request.Text))
            {
                ReportBuilder.AppendLine($"* '{template.Name}' не подходит, включен пропуск пустых отзывов.");
                return true;
            }

            if (template.Settings.IsSkipWithTextFeedbacks && string.IsNullOrEmpty(Request.Text) == false)
            {
                ReportBuilder.AppendLine($"* '{template.Name}' не подходит, включен пропуск отзывов с тексом.");
                return true;
            }

            ReportBuilder.AppendLine($"* '{template.Name}' проходит проверку настроек.");

            return false;
        }
    }
}
