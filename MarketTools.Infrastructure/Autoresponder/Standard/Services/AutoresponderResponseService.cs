using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Utilities.Autoresponder.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketTools.Infrastructure.Autoresponder.Standard.ResponseHandlers;

namespace MarketTools.Infrastructure.Autoresponder.Standard.Services
{
    internal class AutoresponderResponseService(IContextService<AutoresponderContext> _autoresponderContext)
        : IAutoresponderResponseService
    {
        public AutoresponderResultModel Build(AutoresponderRequestModel request)
        {
            StringBuilder reportBuilder = new StringBuilder();
            AutoresponderContext context = _autoresponderContext.Context;

            try
            {
                string responseText = new AutoresponderResponseChainBuilder<AutoresponderRequestModel>(context, request, reportBuilder, request)
                    .Use(new SelectionRatingResponseHandler())
                    .Use(new SelectionTemplatesResponseHandler())
                    .Use(new BlackListFilterResponseHandler())
                    .Use(new SkipSettingsFilterResponseHandler())
                    .Use(new SelectionColumnTypeResponseHandler())
                    .Use(new FilterEmptyColumnTypeResponseHandler())
                    .Use(new SelectionTemplateResponsseHandler())
                    .Use(new ResponseTextBuildHandler())
                    .Use(new RecommendationReplacerResponseHandler())
                    .Use(new ResponseTextValidationHandler())
                    .Get();

                return Create(true, reportBuilder, responseText);
            }
            catch (Exception ex)
            {
                AddErrorMessage(ex, reportBuilder);
                return Create(false, reportBuilder);
            }
        }

        private void AddErrorMessage(Exception ex, StringBuilder reportBuilder)
        {
            reportBuilder.AppendLine("");
            reportBuilder.AppendLine($"Ошибка: {ex.Message}");
        }

        private AutoresponderResultModel Create(bool isSuccess, StringBuilder reportBuilder, string responseMessage = "")
        {
            return new AutoresponderResultModel
            {
                IsSuccess = isSuccess,
                Text = responseMessage.Trim(),
                Report = reportBuilder.ToString().Trim()
            };
        }
    }
}
