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
    internal class BlackListFilterResponseHandler
        : AutoresponderResponseHandler<IEnumerable<StandardAutoresponderTemplateEntity>, IEnumerable<StandardAutoresponderTemplateEntity>>
    {
        private string _lowerText = null!;

        public override IEnumerable<StandardAutoresponderTemplateEntity> Handle(IEnumerable<StandardAutoresponderTemplateEntity> body)
        {
            ReportBuilder.AppendLine("- Проверка черного списка для шаблонов.");

            _lowerText = Request.Text.ToLower();
            List<StandardAutoresponderTemplateEntity> filterTemplates = new List<StandardAutoresponderTemplateEntity>();

            foreach(StandardAutoresponderTemplateEntity template in body)
            {
                if (template.BlackList == null)
                {
                    ReportBuilder.AppendLine($"* '{template.Name}' без черного списка, проверка не проводится.");
                    filterTemplates.Add(template);
                    continue;
                }

                if (TryFindBanWord(template.BlackList, out string badWord))
                {
                    ReportBuilder.AppendLine($"* В отзыве найдено '{badWord}'. Шаблон '{template.Name}' пропускается.");
                    continue;
                }

                ReportBuilder.AppendLine($"* '{template.Name}' прошел проверку.");
                filterTemplates.Add(template);
            }

            if(filterTemplates.Count == 0)
            {
                throw new Exception("Ни один шаблон не прошел проверку черного списка.");
            }

            return filterTemplates;
        }

        private bool TryFindBanWord(StandardAutoresponderBlackListEntity blackList, out string badWord)
        {
            badWord = string.Empty;

            StandardAutoresponderBanWordEntity? banWordEntity = blackList
                .BanWords
                .FirstOrDefault(badWord => _lowerText.Contains(badWord.Value.ToLower()));

            if (banWordEntity == null)
            {
                return false;
            }

            badWord = banWordEntity.Value;

            return true;
        }
    }
}
