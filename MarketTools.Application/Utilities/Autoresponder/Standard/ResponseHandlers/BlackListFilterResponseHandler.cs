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
    internal class BlackListFilterResponseHandler
        : AutoresponderResponseHandler<IEnumerable<StandardAutoresponderTemplateEntity>, IEnumerable<StandardAutoresponderTemplateEntity>>
    {
        private readonly string _lowerText;

        public BlackListFilterResponseHandler(AutoresponderContext context, AutoresponderRequestModel request, StringBuilder reportBuilder) 
            : base(context, request, reportBuilder)
        {
            _lowerText = request.Text.ToLower();
        }

        public override IEnumerable<StandardAutoresponderTemplateEntity> Handle(IEnumerable<StandardAutoresponderTemplateEntity> body)
        {
            List<StandardAutoresponderTemplateEntity> filterTemplates = new List<StandardAutoresponderTemplateEntity>();

            AddStartCheckMessage();

            foreach (StandardAutoresponderTemplateEntity template in body)
            {
                if(template.BlackList == null)
                {
                    ReportBuilder.AppendLine($"* ${template.Name} без черного списка.");
                    filterTemplates.Add(template);
                    continue;
                }

                if(TryFindBanWord(template.BlackList, out string badWord))
                {
                    ReportBuilder.AppendLine($"* В отзыве найдено '${badWord}'. Шаблон {template.Name} пропускается.");
                }

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

        private void AddStartCheckMessage()
        {
            ReportBuilder.AppendLine("");
            ReportBuilder.AppendLine("- Проверка черного списка для шаблонов.");
        }
    }
}
