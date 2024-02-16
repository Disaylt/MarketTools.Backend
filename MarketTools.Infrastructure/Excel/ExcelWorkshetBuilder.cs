using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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
            IXLRow row = _xLWorksheet.Row(1);
            foreach (ColumnDetailsDto columnDetail in columnsDetail)
            {
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

        public ExcelWorkshetBuilder SetWrapText(bool isActive)
        {
            _xLWorksheet.Style.Alignment.WrapText = isActive;

            return this;
        }

        public IXLWorksheet Build()
        {
            return _xLWorksheet;
        }
    }
}
