using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Excel
{
    public abstract class ExcelBase
    {
        protected Stream SaveAs(IXLWorkbook workbook)
        {
            Stream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return stream;
        }
    }
}
