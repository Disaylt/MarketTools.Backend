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
        : AutoresponderResponseHandler<IEnumerable<ResponseBuildDetails>, IEnumerable<ResponseBuildDetails>>
    {
        public FilterEmptyColumnTypeResponseHandler(AutoresponderContext context, AutoresponderRequestModel request, StringBuilder reportBuilder) 
            : base(context, request, reportBuilder)
        {
        }

        public override IEnumerable<ResponseBuildDetails> Handle(IEnumerable<ResponseBuildDetails> body)
        {
            ReportBuilder.AppendLine($"- Проверка сущетсвования колонок выбранного типа ответов.");

            body = body
                .Where(x =>
                {
                    if(IsEmptyColumns(x))
                    {
                        ReportBuilder.AppendLine($"* ${x.Template.Name} не содержит колонок выбранного типа.");
                        return false;
                    }

                    ReportBuilder.AppendLine($"* ${x.Template.Name} содержит колоноки выбранного типа.");

                    return true;
                });

            if(body.Any() == false)
            {
                throw new Exception("После проверки колонок список доступных шаблонов пуст.");
            }

            return body;
        }

        private bool IsEmptyColumns(ResponseBuildDetails responseBuildDetails)
        {
            return responseBuildDetails.Template
                .BindPositions
                .Select(x => x.Column)
                .Any(x => x.Type == responseBuildDetails.ColumnType);
        }
    }
}
