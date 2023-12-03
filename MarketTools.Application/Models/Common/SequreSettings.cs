using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Common
{
    public class SequreSettings
    {
        public IEnumerable<string> Proxies { get; set; } = Enumerable.Empty<string>();
        public required TelegramBotsStorage TelegramBots { get; set; }
        public required DatabaseConnectionsStorage DatabaseConnections { get; set; }
    }

    public class DatabaseConnectionsStorage
    {
        private string? _main;
        public string Main
        {
            get
            {
                return _main ?? throw new NullReferenceException();
            }
            set
            {
                _main = value;
            }
        }
    }

    public class TelegramBotsStorage
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
