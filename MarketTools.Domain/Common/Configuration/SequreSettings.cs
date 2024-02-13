using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Common.Configuration
{
    public class SequreSettings
    {
        public IEnumerable<string> Proxies { get; set; } = Enumerable.Empty<string>();
        public required TelegramBots TelegramBots { get; set; }
        public required Database Database { get; set; }
        public required Jwt Jwt { get; set; }
    }
}
