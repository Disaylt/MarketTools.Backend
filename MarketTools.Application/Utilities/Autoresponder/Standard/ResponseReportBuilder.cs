using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.Autoresponder.Standard
{
    internal class ResponseReportBuilder : ITemplateReportBuilder, IResponseReportBuilder
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public string Build()
        {
            return _builder.ToString();
        }

        public ITemplateReportBuilder AddNotHasColumnTypeMessage()
        {
            _builder.AppendLine($"- В шаблоне не найдены колонки с выбранным типом ответа.");

            return this;
        }

        public ITemplateReportBuilder AddColumnTypeMessage(AutoresponderColumnType type)
        {
            switch (type)
            {
                case AutoresponderColumnType.Standard:
                    _builder.AppendLine($"- Артикул не найден в таблице рекомендаций, выбираем стандартные колонки.");
                    return this;
                case AutoresponderColumnType.Recommendation:
                    _builder.AppendLine($"- Артикул найден в таблице рекомендаций, выбираем колонки с рекоммендациями.");
                    return this;
                default :
                    _builder.AppendLine($"- Неизвестный тип колонки.");
                    return this;
            }
        }

        public ITemplateReportBuilder AddBadCheckSettingMessage()
        {
            _builder.AppendLine($"- Отзыв не удовлетворяет требованиям настроек.");

            return this;
        }

        public ITemplateReportBuilder AddCheckSettingsMessage()
        {
            _builder.AppendLine($"- Проверка настроек шаблона.");

            return this;
        }

        public ITemplateReportBuilder AddFindBanWordMessage(string banWord)
        {
            _builder.AppendLine($"- В отзыве найдено слово из черного списка '${banWord}'.");

            return this;
        }

        public ITemplateReportBuilder AddCheckBanWords(StandardAutoresponderBlackListEntity blackList)
        {
            _builder.AppendLine($"- Проверка черного списка '${blackList.Name}'.");

            return this;
        }

        public ITemplateReportBuilder AddCheckTemplateMessage(StandardAutoresponderTemplateEntity tempalte)
        {
            _builder.AppendLine("");
            _builder.AppendLine($"- Проверка шаблона '${tempalte.Name}'");

            return this;
        }

        public void AddCreateResponseMessage(string message)
        {
            _builder.AppendLine("");
            _builder.AppendLine($"- Сформировал первичный ответ. Длинна ответа ${message.Length} символов.");
        }

        public void AddSelectionTemplateMessage(StandardAutoresponderTemplateEntity tempalte)
        {
            _builder.AppendLine("");
            _builder.AppendLine($"- Выбран шаблон '${tempalte.Name}'");
        }

        public void AddErrorMessage(Exception ex)
        {
            _builder.AppendLine("");
            _builder.AppendLine($"Ошибка: ${ex.Message}");
        }

        public void AddSelectTemplatesMessage(IEnumerable<StandardAutoresponderTemplateEntity> templates)
        {
            int numTemplates = templates.Count();
            _builder.AppendLine($"- В списке найдено ${numTemplates} подходящих шаблонов для создания ответа.");
        }

        public void AddSelectRatingMessage(StandardAutoresponderConnectionRatingEntity ratingEntity)
        {
            _builder.AppendLine($"- Проверка на присутсвие списка шаблонов для оценки ${ratingEntity.Rating} успешно пройдена.");
        }
    }
}
