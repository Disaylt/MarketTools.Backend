using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Common.Configuration
{
    public class Database
    {
        private string? _mainConnectionString;
        public string MainConnectionString
        {
            get
            {
                return _mainConnectionString ?? throw new NullReferenceException();
            }
            set
            {
                _mainConnectionString = value;
            }
        }
    }
}
