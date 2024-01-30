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

        public bool TrySelect(StandardAutoresponderTemplateEntity tempalte, out ResponseBuildDetails templateSelectDetails)
        {
            _templateReport.AddCheckTemplateMessage(tempalte);

            templateSelectDetails = new ResponseBuildDetails
            {
                Template = tempalte
            };


            templateSelectDetails.ColumnType = SelectColumnType();
            _templateReport.AddColumnTypeMessage(templateSelectDetails.ColumnType);
            if(IsContainsTypeColumns(templateSelectDetails) == false)
            {
                _templateReport.AddNotHasColumnTypeMessage();
                return false;
            }

            return true;
        }

        private bool IsContainsTypeColumns(ResponseBuildDetails templateSelectDetails)
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
    }
}
