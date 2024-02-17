using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.Autoresponder.Standard.ResponseHandlers
{
    internal class ResponseTextBuildHandler
        : AutoresponderResponseHandler<TemplateDetails, ResponseDetails>
    {
        private static Random _random = new Random();

        public override ResponseDetails Handle(TemplateDetails body)
        {
            IEnumerable<string> partMessages = GetColumnsText(body);

            StringBuilder messageBuilder = new StringBuilder();
            string text = messageBuilder.AppendJoin(' ', partMessages)
                .ToString()
                .Trim();

            ReportBuilder.AppendLine($"- Создание текста ответа.");

            return new ResponseDetails 
            { 
                Text = text,
                ColumnType = body.ColumnType
            };
        }

        private IEnumerable<string> GetColumnsText(TemplateDetails body)
        {
            return body
                .Template
                .BindPositions
                .Where(x => x.Column.Type == body.ColumnType && x.Column.Cells.Count > 0)
                .OrderBy(x => x.Position)
                .Select(x =>
                {
                    int index = _random.Next(x.Column.Cells.Count);
                    return x.Column.Cells[index].Value;
                });
        }
    }
}
