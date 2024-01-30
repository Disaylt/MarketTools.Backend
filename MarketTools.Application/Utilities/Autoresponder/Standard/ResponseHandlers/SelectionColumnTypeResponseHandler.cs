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

namespace MarketTools.Application.Utilities.Autoresponder.Standard.ResponseHandlers
{
    internal class SelectionColumnTypeResponseHandler
        : AutoresponderResponseHandler<IEnumerable<StandardAutoresponderTemplateEntity>, IEnumerable<ResponseBuildDetails>>
    {
        public SelectionColumnTypeResponseHandler(AutoresponderContext context, AutoresponderRequestModel request, StringBuilder reportBuilder) : base(context, request, reportBuilder)
        {
        }

        public override IEnumerable<ResponseBuildDetails> Handle(IEnumerable<StandardAutoresponderTemplateEntity> body)
        {
            AutoresponderColumnType columnType = SelectColumnType();
            AddColumnTypeMessage(columnType);

            return body
                .Select(x => new ResponseBuildDetails 
                { 
                    Template = x,
                    ColumnType = columnType
                });
        }

        private void AddColumnTypeMessage(AutoresponderColumnType columnType)
        {
            switch (columnType)
            {
                case AutoresponderColumnType.Standard:
                    ReportBuilder.AppendLine($"- Артикул не найден в таблице рекомендаций, выбираем стандартные колонки.");
                    return;
                case AutoresponderColumnType.Recommendation:
                    ReportBuilder.AppendLine($"- Артикул найден в таблице рекомендаций, выбираем колонки с рекоммендациями.");
                    return;
                default:
                    ReportBuilder.AppendLine($"- Неизвестный тип колонки.");
                    return;
            }
        }

        private AutoresponderColumnType SelectColumnType()
        {
            if (Context.RecommendationProducts.Any(x => x.FeedbackArticle == Request.Article))
            {
                return AutoresponderColumnType.Recommendation;
            }

            return AutoresponderColumnType.Standard;
        }
    }
}
