using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Common.Configuration
{
    public class TelegramBots
    {
        private string? _test;
        public string Test
        {
            get
            {
                return _test ?? throw new NullReferenceException();
            }
            set
            {
                _test = value;
            }
        }
    }
}
