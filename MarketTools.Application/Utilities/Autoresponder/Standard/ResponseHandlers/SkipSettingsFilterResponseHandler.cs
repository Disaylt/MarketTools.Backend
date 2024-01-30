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
            AddStartCheckMessage();

            IEnumerable<StandardAutoresponderTemplateEntity> filterTemplates = body
                .Where(x =>
                {
                    if (x.Settings.IsSkipEmptyFeedbacks && string.IsNullOrEmpty(Request.Text))
                    {
                        ReportBuilder.AppendLine($"* ${x.Name} не подходит, включен пропуск пустых отзывов.");
                        return false;
                    }

                    if (x.Settings.IsSkipWithTextFeedbacks && string.IsNullOrEmpty(Request.Text) == false)
                    {
                        ReportBuilder.AppendLine($"* ${x.Name} не подходит, включен пропуск отзывов с тексом.");
                        return false;
                    }

                    ReportBuilder.AppendLine($"* ${x.Name} проходит проверку настроек.");

                    return true;
                });

            if (filterTemplates.Any() == false)
            {
                throw new Exception("Ни один шаблон не прошел проверку настроек.");
            }

            return filterTemplates;
        }

        private void AddStartCheckMessage()
        {
            ReportBuilder.AppendLine("");
            ReportBuilder.AppendLine("- Проверка настроек шаблона.");
        }
    }
}
