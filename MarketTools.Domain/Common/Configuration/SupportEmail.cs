using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Common.Configuration
{
    public class SupportEmail
    {
        private string? _email;
        public string Email
        {
            get
            {
                return _email ?? throw new NullReferenceException();
            }
            set { _email = value; }
        }

        private string? _password;
        public string Password
        {
            get
            {
                return _password ?? throw new NullReferenceException();
            }
            set { _password = value; }
        }
    }
}
