using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Autoresponder.Standard
{
    public interface ITemplateReportBuilder : IMessageBuilder
    {
        public ITemplateReportBuilder AddCheckTemplateMessage(StandardAutoresponderTemplateEntity tempalte);
        public ITemplateReportBuilder AddCheckBanWords(StandardAutoresponderBlackListEntity blackList);
        public ITemplateReportBuilder AddCheckSettingsMessage();
        public ITemplateReportBuilder AddFindBanWordMessage(string banWord);
        public ITemplateReportBuilder AddBadCheckSettingMessage();
        public ITemplateReportBuilder AddColumnTypeMessage(AutoresponderColumnType type);
        public ITemplateReportBuilder AddNotHasColumnTypeMessage();
    }
}
