using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Excel
{
    public interface IExcelWriter<T>
    {
        public Stream Write(IEnumerable<T> data);
    }
}
