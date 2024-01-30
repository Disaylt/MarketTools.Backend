using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.Autoresponder.Standard.ResponseHandlers
{
    internal class SkipSettingsFilterResponseHandler
        : AutoresponderResponseHandler<IEnumerable<StandardAutoresponderTemplateEntity>, IEnumerable<StandardAutoresponderTemplateEntity>>
    {
        public SkipSettingsFilterResponseHandler(AutoresponderContext context, AutoresponderRequestModel request, StringBuilder reportBuilder) 
            : base(context, request, reportBuilder)
        {
        }

        public override IEnumerable<StandardAutoresponderTemplateEntity> Handle(IEnumerable<StandardAutoresponderTemplateEntity> body)
        {
            ReportBuilder.AppendLine("- Проверка настроек шаблона.");

            IEnumerable<StandardAutoresponderTemplateEntity> filterTemplates = body
                .Where(IsSkip);

            if (filterTemplates.Any() == false)
            {
                throw new Exception("Ни один шаблон не прошел проверку настроек.");
            }

            return filterTemplates;
        }

        private bool IsSkip(StandardAutoresponderTemplateEntity template)
        {
            if (template.Settings.IsSkipEmptyFeedbacks && string.IsNullOrEmpty(Request.Text))
            {
                ReportBuilder.AppendLine($"* ${template.Name} не подходит, включен пропуск пустых отзывов.");
                return false;
            }

            if (template.Settings.IsSkipWithTextFeedbacks && string.IsNullOrEmpty(Request.Text) == false)
            {
                ReportBuilder.AppendLine($"* ${template.Name} не подходит, включен пропуск отзывов с тексом.");
                return false;
            }

            ReportBuilder.AppendLine($"* ${template.Name} проходит проверку настроек.");

            return true;
        }
    }
}
