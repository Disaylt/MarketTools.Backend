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

namespace MarketTools.Application.Utilities.Autoresponder.Standard
{
    public class TemplateSelectionDetailsUtility(IEnumerable<StandardAutoresponderRecommendationProductEntity> _recommendationProducts,
        AutoresponderRequestModel _autoresponderRequest,
        ITemplateReportBuilder _templateReport)
    {

        public bool TrySelect(StandardAutoresponderTemplateEntity tempalte, out TemplateSelectionDetails templateSelectDetails)
        {
            _templateReport.AddCheckTemplateMessage(tempalte);

            templateSelectDetails = new TemplateSelectionDetails
            {
                Template = tempalte
            };

            if(tempalte.BlackList != null)
            {
                _templateReport.AddCheckBanWords(tempalte.BlackList);

                if (TryFindBanWord(tempalte.BlackList, out string banWord))
                {
                    _templateReport.AddFindBanWordMessage(banWord);
                    return false;
                }
            }

            _templateReport.AddCheckSettingsMessage();
            if (IsSkipAfterCheckSettings(tempalte.Settings))
            {
                _templateReport.AddBadCheckSettingMessage();
                return false;
            }

            templateSelectDetails.ColumnType = SelectColumnType();
            _templateReport.AddColumnTypeMessage(templateSelectDetails.ColumnType);
            if(IsContainsTypeColumns(templateSelectDetails) == false)
            {
                _templateReport.AddNotHasColumnTypeMessage();
                return false;
            }

            return true;
        }

        private bool IsContainsTypeColumns(TemplateSelectionDetails templateSelectDetails)
        {
            return templateSelectDetails.Template
                .BindPositions
                .Select(x=> x.Column)
                .Any(x=> x.Type == templateSelectDetails.ColumnType);
        }

        private AutoresponderColumnType SelectColumnType()
        {
            if(_recommendationProducts.Any(x => x.FeedbackArticle == _autoresponderRequest.Article))
            {
                return AutoresponderColumnType.Recommendation;
            }

            return AutoresponderColumnType.Standard;
        }

        private bool IsSkipAfterCheckSettings(StandardAutoresponderTemplateSettingsEntity settings)
        {
            if (settings.IsSkipEmptyFeedbacks && string.IsNullOrEmpty(_autoresponderRequest.Text))
            {
                return true;
            }

            if(settings.IsSkipWithTextFeedbacks && string.IsNullOrEmpty(_autoresponderRequest.Text) == false)
            {
                return true;
            }

            return false;
        }

        private bool TryFindBanWord(StandardAutoresponderBlackListEntity blackList, out string badWord)
        {
            badWord = string.Empty;

            string lowerFeedback = _autoresponderRequest.Text.ToLower();

            StandardAutoresponderBanWordEntity? banWordEntity = blackList
                .BanWords
                .FirstOrDefault(badWord => lowerFeedback.Contains(badWord.Value.ToLower()));

            if (banWordEntity == null)
            {
                return false;
            }

            badWord = banWordEntity.Value;

            return true;
        }
    }
}
