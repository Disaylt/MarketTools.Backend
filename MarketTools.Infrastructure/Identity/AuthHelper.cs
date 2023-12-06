using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Identity
{
    public class AuthHelper : IAuthReadHelper, IAuthWriteHelper
    {
        private string? _userId;
        public string UserId
        {
            get
            {
                if(_userId == null)
                {
                    throw new IdentityUnauthorizedException();
                }

                return _userId;
            }
        }

        public void Set(string userId)
        {
            _userId = userId;
        }
    }
}
