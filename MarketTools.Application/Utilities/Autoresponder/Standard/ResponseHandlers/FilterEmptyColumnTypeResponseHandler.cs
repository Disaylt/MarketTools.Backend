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
    internal class FilterEmptyColumnTypeResponseHandler
        : AutoresponderResponseHandler<ResponseBuildDetails, ResponseBuildDetails>
    {
        public FilterEmptyColumnTypeResponseHandler(AutoresponderContext context, AutoresponderRequestModel request, StringBuilder reportBuilder) 
            : base(context, request, reportBuilder)
        {
        }

        public override ResponseBuildDetails Handle(ResponseBuildDetails body)
        {
            ReportBuilder.AppendLine($"- Проверка сущетсвования колонок выбранного типа ответов.");

            body.Templates = body.Templates
                .Where(x =>
                {
                    if(IsEmptyColumns(x, body.ColumnType))
                    {
                        ReportBuilder.AppendLine($"* ${x.Name} не содержит колонок выбранного типа.");
                        return false;
                    }

                    ReportBuilder.AppendLine($"* ${x.Name} содержит колоноки выбранного типа.");

                    return true;
                });

            return body;
        }

        private bool IsEmptyColumns(StandardAutoresponderTemplateEntity template, AutoresponderColumnType columnType)
        {
            return template
                .BindPositions
                .Select(x => x.Column)
                .Any(x => x.Type == columnType);
        }
    }
}
