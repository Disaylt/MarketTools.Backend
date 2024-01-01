using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using MarketTools.Infrastructure.Services.Autoresponder.Standard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Excel
{
    internal class ExcelWorkshetBuilder
    {
        private readonly IXLWorksheet _xLWorksheet;
        public ExcelWorkshetBuilder(IXLWorkbook workbook, string name = "data") 
        {
            _xLWorksheet = workbook.AddWorksheet(name);
        }

        public ExcelWorkshetBuilder AddHeaders(IEnumerable<ColumnDetailsDto> columnsDetail)
        {
            foreach(ColumnDetailsDto columnDetail in columnsDetail)
            {
                IXLRow row = _xLWorksheet.Row(1);
                row.Cell(columnDetail.Position).Value = columnDetail.Name;
            }

            return this;
        }

        public ExcelWorkshetBuilder SetWidth(IEnumerable<ColumnDetailsDto> columnsDetail)
        {
            foreach (ColumnDetailsDto columnDetail in columnsDetail)
            {
                _xLWorksheet.Column(columnDetail.Position).Width = columnDetail.Width;
            }

            return this;
        }

        public IXLWorksheet Build()
        {
            return _xLWorksheet;
        }
    }
}
