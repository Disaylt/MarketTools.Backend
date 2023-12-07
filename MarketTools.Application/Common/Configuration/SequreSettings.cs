using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Configuration
{
    public class SequreSettings
    {
        public IEnumerable<string> Proxies { get; set; } = Enumerable.Empty<string>();
        public required TelegramBotsStorage TelegramBots { get; set; }
        public required DatabaseConnectionsStorage DatabaseConnections { get; set; }
        public required JwtStorage Jwt { get; set; }
    }

    public class JwtStorage
    {
        public int ExpireDay { get; set; } = 1;

        private string? _validAudience;
        public string ValidAudience
        {
            get
            {
                return _validAudience ?? throw new NullReferenceException();
            }
            set { _validAudience = value; }
        }

        private string? _validIssuer;
        public string ValidIssuer
        {
            get
            {
                return _validIssuer ?? throw new NullReferenceException();
            }
            set { _validIssuer = value; }
        }

        private string? _secret;
        public string Secret
        {
            get
            {
                return _secret ?? throw new NullReferenceException();
            }
            set { _secret = value; }
        }
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
