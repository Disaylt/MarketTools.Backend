using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Application.Utilities.Autoresponder.Standard;
using MarketTools.Application.Utilities.Autoresponder.Standard.ResponseHandlers;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Services.Autroesponder.Standard
{
    internal class AutoresponderResponseService
        (AutoresponderContext _context)
        : IAutoresponderResponseService
    {
        private readonly StringBuilder _reportBuilder = new StringBuilder();

        public AutoresponderResultModel Build(AutoresponderRequestModel request)
        {
            try
            {
                StandardAutoresponderConnectionRatingEntity ratingEntity = new SelectionRatingResponseHandler(_context, request, _reportBuilder).Handle(request);
                IEnumerable<StandardAutoresponderTemplateEntity> templates = new SelectionTemplatesResponseHandler(_context, request, _reportBuilder).Handle(ratingEntity);
                templates = new BlackListFilterResponseHandler(_context, request, _reportBuilder).Handle(templates);
                templates = new SkipSettingsFilterResponseHandler(_context, request, _reportBuilder).Handle(templates);
                IEnumerable<TemplateDetails> templatesDetails = new SelectionColumnTypeResponseHandler(_context, request, _reportBuilder).Handle(templates);
                templatesDetails = new FilterEmptyColumnTypeResponseHandler(_context, request, _reportBuilder).Handle(templatesDetails);
                TemplateDetails templateDetails = new SelectionTemplateResponsseHandler(_context, request, _reportBuilder).Handle(templatesDetails);
                ResponseDetails responseDetails = new ResponseTextBuildHandler(_context, request, _reportBuilder).Handle(templateDetails);
                responseDetails = new RecommendationReplacerResponseHandler(_context, request, _reportBuilder).Handle(responseDetails);

                return Create(true);
            }
            catch(Exception ex)
            {
                AddErrorMessage(ex);
                return Create(false);
            }
        }

        private string ReplaceBindWords(string text, TemplateDetails templateSelectionDetails, AutoresponderRequestModel request)
        {
            if (templateSelectionDetails.ColumnType == AutoresponderColumnType.Standard)
            {
                return text;
            }

            List<StandardAutoresponderRecommendationProductEntity> articles = _context.RecommendationProducts
                .Where(x => x.FeedbackArticle == request.Article)
                .ToList();

            if(articles.Count == 0)
            {
                throw new Exception("Не найдено ни одного ариткула из отзыва для рекомендации.");
            }


        }

        private void AddErrorMessage(Exception ex)
        {
            _reportBuilder.AppendLine("");
            _reportBuilder.AppendLine($"Ошибка: ${ex.Message}");
        }

        private AutoresponderResultModel Create(bool isSuccess, string responseMessage = "")
        {
            return new AutoresponderResultModel
            {
                IsSuccess = isSuccess,
                Message = responseMessage,
                Report = _reportBuilder.ToString()
            };
        }
    }
}
