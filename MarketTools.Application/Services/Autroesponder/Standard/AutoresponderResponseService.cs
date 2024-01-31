using MarketTools.Application.Common.Exceptions;
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
        : IAutoresponderResponseService
    {
        private readonly IAutoresponderContextReader _contextReader;

        public AutoresponderResponseService(IAutoresponderContextReader contextReader)
        {
            _contextReader = contextReader;
        }

        public AutoresponderResultModel Build(AutoresponderRequestModel request)
        {
            StringBuilder reportBuilder = new StringBuilder();
            AutoresponderContext context = _contextReader.Context;

            try
            {
                StandardAutoresponderConnectionRatingEntity ratingEntity = new SelectionRatingResponseHandler(context, request, reportBuilder).Handle(request);
                IEnumerable<StandardAutoresponderTemplateEntity> templates = new SelectionTemplatesResponseHandler(context, request, reportBuilder).Handle(ratingEntity);
                templates = new BlackListFilterResponseHandler(context, request, reportBuilder).Handle(templates);
                templates = new SkipSettingsFilterResponseHandler(context, request, reportBuilder).Handle(templates);
                IEnumerable<TemplateDetails> templatesDetails = new SelectionColumnTypeResponseHandler(context, request, reportBuilder).Handle(templates);
                templatesDetails = new FilterEmptyColumnTypeResponseHandler(context, request, reportBuilder).Handle(templatesDetails);
                TemplateDetails templateDetails = new SelectionTemplateResponsseHandler(context, request, reportBuilder).Handle(templatesDetails);
                ResponseDetails responseDetails = new ResponseTextBuildHandler(context, request, reportBuilder).Handle(templateDetails);
                responseDetails = new RecommendationReplacerResponseHandler(context, request, reportBuilder).Handle(responseDetails);
                string responseText = new ResponseTextValidationHandler(context, request, reportBuilder).Handle(responseDetails.Text);

                return Create(true, reportBuilder, responseText);
            }
            catch(Exception ex)
            {
                AddErrorMessage(ex, reportBuilder);
                return Create(false, reportBuilder);
            }
        }

        private void AddErrorMessage(Exception ex, StringBuilder reportBuilder)
        {
            reportBuilder.AppendLine("");
            reportBuilder.AppendLine($"Ошибка: ${ex.Message}");
        }

        private AutoresponderResultModel Create(bool isSuccess, StringBuilder reportBuilder, string responseMessage = "")
        {
            return new AutoresponderResultModel
            {
                IsSuccess = isSuccess,
                Message = responseMessage,
                Report = reportBuilder.ToString()
            };
        }
    }
}
