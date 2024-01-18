using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Excel
{
    public interface IExcelReader<T> where T : class
    {
        public IEnumerable<T> Read(Stream stream);
    }
}
