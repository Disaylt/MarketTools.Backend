﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Common.Exceptions
{
    public class IdentityUnauthorizedException : Exception
    {
        public IdentityUnauthorizedException() : base("Пользователь не авторизован.") { }
        public IdentityUnauthorizedException(string message) : base(message) { }
    }
}
