using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Common.Configuration
{
    public class Jwt
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
}
